using UnityEngine;
using System.Collections;
using System;

public class Kar98KBehaviour : WeaponBehaviour
{

    public K98Behaviour faca;
    public bool atacarComFaca;

    // Use this for initialization
    void Start()
    {
        this.podeAtirar = true;
        this.dano = 25;
        this.alcance = 0.8f;
        this.penetracao = 1;
        this.capacidade = 5;
        this.tempo = 4;
        this.tempoEntreDisparos = 4;
        this.precisao = 0.8f;

        this.danoPequena = 25;
        this.danoMedio = 18.75f;
        this.danoLongo = 12.5f;
        this.atacarComFaca = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.Atirar(new LandserBehaviour());
        }
    }

    public override void Atirar(PlayerBehaviour alvo)
    {
        if (this.atacarComFaca)
        {
            this.atacarComFaca = false;
            this.faca.Atacar(alvo);
            StartCoroutine(Esperar());
        }
        if (this.podeAtirar)
        {
            this.podeAtirar = false;
            //float distancia = Vector3.Distance(this.canoDaArma.transform.position, alvo.transform.position);
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

    public override void AtivarOuDesativarHabilidade()
    {
        if (this.atacarComFaca)
        {
            this.faca.gameObject.SetActive(false);
            this.atacarComFaca = false;
            this.podeAtirar = true;
        }
        else
        {
            this.faca.gameObject.SetActive(true);
            this.podeAtirar = false;
            this.atacarComFaca = true;
        }
    }

    public IEnumerator EsperarPraAtirar()
    {
        float tempo = this.tempoEntreDisparos;
        yield return new WaitForSeconds(tempo);
        this.podeAtirar = true;
    }

    private IEnumerator Esperar()
    {
        yield return new WaitForSeconds(this.tempo);
        this.atacarComFaca = true;
    }

    public override IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(this.tempo);
        this.capacidade = 5;
        this.podeAtirar = true;
    }
}
