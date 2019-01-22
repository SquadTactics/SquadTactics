using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class StrelokBehaviour : PlayerBehaviour
{

    // Use this for initialization
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
        if (this.vida <= 0)
        {
            Destroy(this.gameObject, 1);
        }

        if (this.alvo != null)
        {
            this.modoAtaque = true;
        }
        else
        {
            this.modoAtaque = false;
        }

        if (this.modoAtaque)
        {
            if (!(this.alvo.GetVida() <= 0))
            {
                weapon.Atirar(this.alvo);
            }
        }
    }

    public override void LevaDano(float dano)
    {
        this.vida -= dano;
    }

    public override void Movimentar(Vector3 position)
    {
        // Disparar um raio da posição do mouse
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            destino = hit.point;
            agente.SetDestination(destino);
        }
    }
}
