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
            int tempo = (int)UnityEngine.Random.Range(4, 6);
            StartCoroutine(Disparar(alvo, tempo));
        }
    }

    private IEnumerator Disparar(PlayerBehaviour alvo, int tempo)
    {
        Instantiate(this.projetil, this.canoDaArma.transform.position, this.canoDaArma.rotation);
        this.capacidade--;
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
