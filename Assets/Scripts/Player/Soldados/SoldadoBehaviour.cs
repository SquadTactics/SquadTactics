using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using System;

public abstract class SoldadoBehaviour : PlayerBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.GetComponents();
        this.podeJogar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetVida() <= 0)
        {
            Destroy(this.gameObject, 1);
        }

        if (this.alvo != null)
        {
            this.transform.LookAt(this.alvo.transform);
            this.modoAtaque = true;
        } else
        {
            this.modoAtaque = false;
        }

        if (this.modoAtaque)
        {
            if (!(this.alvo.GetVida() <= 0))
            {
                this.modoAtaque = false;
                weapon.Atirar(this.alvo);
            } else
            {
                this.alvo = null;
            }
        }

        if (Input.GetMouseButtonDown(0) && this.podeJogar)
        {
            this.podeJogar = false;
            Instantiate(this.bomba, this.lancarBomba.transform.position, this.lancarBomba.transform.rotation);
            StartCoroutine(Esperar());
        }
        this.Skills();
    }

    public abstract void Skills();

    public void ModoAgachado()
    {
        // TODO.
    }

    public void AumentarVelocidadeDeCorrer()
    {
        // TODO.
    }

    public void ArremessarGranada()
    {
        // TODO.
    }

    private IEnumerator Esperar()
    {
        yield return new WaitForSeconds(30);
        this.podeJogar = true;
    }

    public override void Movimentar(Vector3 position)
    {
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            destino = hit.point;
            agente.SetDestination(destino);
        }
    }

    public override void Rotacionar(Vector3 position)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(position), out hit, 100))
        {
            Vector3 p = hit.point - transform.position;
            p.y = 0;
            Quaternion newR = Quaternion.LookRotation(p);
            this.transform.rotation = newR;
        }
    }

    public override void LevaDano(float dano)
    {
        this.vida -= dano;
    }

    private void GetComponents()
    {
        this.agente = this.GetComponent<NavMeshAgent>();
        this.weapon = this.GetComponentInChildren<WeaponBehaviour>();
        this.vida = 100;
    }
}
