
using UnityEngine;
using System.Collections;

public class P38Behaviour : WeaponBehaviour {


    // Use this for initialization
    void Start()
    {
        this.capacidade = 8;
        this.danoPequena = 12;
        this.danoMedio = 9;
        this.danoLongo = 6;
        this.podeAtirar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.capacidade == 0)
        {
            this.podeAtirar = false;
            StartCoroutine(Recarregar());
        }
    }

    public override void Atirar(PlayerBehaviour alvo)
    {
        if (this.podeAtirar) {
            this.podeAtirar = false;
            Instantiate(this.projetil, this.canoDaArma.position, this.canoDaArma.rotation);
            this.capacidade--;
            StartCoroutine(EsperarPraAtirar());
        }
    }

    private IEnumerator EsperarPraAtirar()
    {
        int tempo = (int)Random.Range(3, 5);
        yield return new WaitForSeconds(tempo);
        this.podeAtirar = true;
        this.disparados = 0;
    }

    public override IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(3);
        this.capacidade = 8;
        this.podeAtirar = true;
    }

    private void CalculaDano(float distancia)
    {
        if (distancia >= 2 && distancia < 3) {
            this.dano = this.danoPequena;
        } else if (distancia >= 3 && distancia <= 3.5f) {
            this.dano = this.danoMedio;
        } else if (distancia > 3.5f && distancia <= 4) {
            this.dano = this.danoLongo;
        }
    }
}
