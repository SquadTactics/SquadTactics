using UnityEngine;
using System.Collections;
using System;

public class NagantM1891ScopedBehaviour : WeaponBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.podeAtirar = true;
        this.capacidade = 5;
        this.danoPequena = 30;
        this.danoMedio = 22.5f;
        this.danoLongo = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.capacidade == 0)
        {
            this.podeAtirar = false;
            StartCoroutine(this.Recarregar());
        }

    }

    public override void Atirar(PlayerBehaviour alvo)
    {
        if (this.podeAtirar)
        {
            this.podeAtirar = false;
            int tempo = UnityEngine.Random.Range(6, 8);
            StartCoroutine(Disparar(alvo, tempo));
        }
    }

    private IEnumerator Disparar(PlayerBehaviour alvo, int tempo)
    {
        float distancia = Vector3.Distance(alvo.transform.position, this.canoDaArma.transform.position);
        this.CalculaDano(distancia);
        alvo.LevaDano(this.dano);
        this.capacidade--;
        yield return new WaitForSeconds(tempo);
        this.podeAtirar = true;
    }

    public override IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(3);
        this.podeAtirar = true;
        this.capacidade = 5;
    }

    private void CalculaDano(float distancia)
    {
        if (distancia >= 2 && distancia <= 6)
        {
            this.dano = this.danoPequena;
        }
        else if (distancia > 6 && distancia <= 10)
        {
            this.dano = this.danoMedio;
        }
        else if (distancia > 10 && distancia <= 14)
        {
            this.dano = this.danoLongo;
        }
    }
}
