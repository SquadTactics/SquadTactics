using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nagant1895Behaviour : WeaponBehaviour
{
    // Start is called before the first frame update
    new void Start()
    {
        this.podeAtirar = true;
        this.capacidade = 7;
        this.danoPequena = 10;
        this.danoMedio = 7.5f;
        this.danoLongo = 5;
    }

    // Update is called once per frame
    new void Update()
    {

        if (this.capacidade <= 0)
        {
            this.podeAtirar = false;
            StartCoroutine(this.Recarregar());
        }
    }

    public void Atirar()
    {
        if (this.podeAtirar)
        {
            this.podeAtirar = false;
            Instantiate(this.projetil, this.canoDaArma.position, this.canoDaArma.rotation);
            this.capacidade--;
            StartCoroutine(this.EsperarPraAtirar());
        }
    }

    private IEnumerator EsperarPraAtirar()
    {
        int tempo = Random.Range(4, 7);
        yield return new WaitForSeconds(tempo);
        this.podeAtirar = true;
    }

    public override IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(3);
        this.podeAtirar = true;
    }

    public override void Atirar(PlayerBehaviour alvo)
    {
        if (this.podeAtirar)
        {
            this.podeAtirar = false;
            float distancia = Vector3.Distance(alvo.transform.position, this.canoDaArma.transform.position);
            this.CalculaDano(distancia);
            alvo.LevaDano(this.dano);
            this.capacidade--;
            StartCoroutine(this.EsperarPraAtirar());
        }
    }

    private void CalculaDano(float distancia)
    {
        if (distancia >= 2 && distancia <= 2.5)
        {
            this.dano = this.danoPequena;
        }
        else if (distancia > 2.5 && distancia <= 3.5)
        {
            this.dano = this.danoMedio;
        }
        else if (distancia > 3.5 && distancia <= 4)
        {
            this.dano = this.danoLongo;
        }
    }
}
