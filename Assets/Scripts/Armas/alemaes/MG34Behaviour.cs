using UnityEngine;
using System.Collections;
using System;

public class MG34Behaviour : WeaponBehaviour
{
    public bool modoSupressao;
    public bool voltarAtivarModoSupressao;

    // Use this for initialization
    void Start()
    {
        this.podeAtirar = true;
        this.modoSupressao = false;
        this.capacidade = 50;
        this.danoPequena = 18;
        this.danoMedio = 13.5f;
        this.danoLongo = 9;
        this.voltarAtivarModoSupressao = false;
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
            if (this.capacidade == 0)
            {
                StartCoroutine(Recarregar());
            } else
            {
                if (!this.modoSupressao)
                {
                    int vezes = (int)UnityEngine.Random.Range(6, 8);
                    StartCoroutine(Disparar(alvo, vezes, 1));
                } else
                {
                    StartCoroutine(Disparar(alvo, 32, 5));
                    this.AtivarOuDesativarHabilidade();
                }
            }

        }
    }

    private IEnumerator Disparar(PlayerBehaviour alvo, int vezes, int tempo)
    {
        for (int i = 0; i < vezes; i++)
        {
            if (this.capacidade > 0)
            {
                Instantiate(this.projetil, this.canoDaArma.transform.position, this.canoDaArma.rotation);
                this.capacidade--;
                yield return new WaitForSeconds(0.2f);
            }
        }
        yield return new WaitForSeconds(tempo);
        this.podeAtirar = true;

    }

    public override void AtivarOuDesativarHabilidade()
    {
        if (this.modoSupressao && this.voltarAtivarModoSupressao)
        {
            this.modoSupressao = false;
            StartCoroutine(Esperar(2.5f));
        }
        else if (!this.voltarAtivarModoSupressao)
        {
            this.modoSupressao = true;
            this.voltarAtivarModoSupressao = true;
        }
    }

    private IEnumerator Esperar(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        this.voltarAtivarModoSupressao = false;
    }

    public override IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(3);
        this.capacidade = 50;
        this.podeAtirar = true;
    }
}
