using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LandserBehaviour : PlayerBehaviour
{
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        this.agente = this.GetComponent<NavMeshAgent>();
        this.weapon = this.GetComponentInChildren<WeaponBehaviour>();
        this.vida = 100;
        this.modoAtaque = true;
    }

    // Update is called once per frame
    void Update()
    {
        //this.Control();

        if (this.vida <= 0) {
            Destroy(this.gameObject, 1);
        }

        if (this.alvo != null) {
            this.transform.LookAt(this.alvo.transform);
            this.modoAtaque = true;
        } else {
            this.modoAtaque = false;
        }

        if (this.modoAtaque) {
            if (!(this.alvo.GetVida() <= 0))
            {
                weapon.Atirar(this.alvo);
            }
        }
    }

    public void Control()
    {
        // Rotação.
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Input.mousePosition;
            this.Rotacionar(mousePos);
        }

        // Movimentar.
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            this.Movimentar(mousePos);
        }
    }

    public override void LevaDano(float dano) {
        this.vida -= dano;
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
}