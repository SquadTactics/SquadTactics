using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nagant1895Behaviour : WeaponBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.podeAtirar = true;
        this.capacidade = 7;
        this.danoPequena = 10;
        this.danoMedio = 7.5f;
        this.danoLongo = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.capacidade <= 0)
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
            Instantiate(this.projetil, this.canoDaArma.transform.position, this.canoDaArma.rotation);
            this.capacidade--;
            StartCoroutine(this.EsperarPraAtirar());
        }
    }

    public override IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(3);
        this.podeAtirar = true;
        this.capacidade = 7;
    }

    private IEnumerator EsperarPraAtirar()
    {
        int tempo = Random.Range(4, 7);
        yield return new WaitForSeconds(tempo);
        this.podeAtirar = true;
    }
}
