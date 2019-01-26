using UnityEngine;
using System.Collections;
using System;

public class Kar98KBehaviour : WeaponBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.podeAtirar = true;
        this.capacidade = 5;
        this.danoPequena = 25;
        this.danoMedio = 18.75f;
        this.danoLongo = 12.5f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void Atirar(PlayerBehaviour alvo)
    {
        if (this.podeAtirar)
        {
            this.podeAtirar = false;
            float distancia = Vector3.Distance(this.canoDaArma.transform.position, alvo.transform.position);
            if (distancia > 20)
            {
                return;
            } else
            {
                if (this.capacidade == 0)
                {
                    StartCoroutine(Recarregar());
                } else
                {
                    Instantiate(this.projetil, this.canoDaArma.position, this.canoDaArma.rotation);
                    this.capacidade--;
                    StartCoroutine(EsperarPraAtirar());
                }
            }
        }
    }

    public IEnumerator EsperarPraAtirar()
    {
        int tempo = UnityEngine.Random.Range(4, 7);
        yield return new WaitForSeconds(tempo);
        this.podeAtirar = true;
    }

    public override IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(3);
        this.capacidade = 5;
        this.podeAtirar = true;
    }
}
