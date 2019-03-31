using UnityEngine;
using System.Collections;

public class DP28Behaviour : WeaponBehaviour {

    public bool modoSupressao;
    public bool voltarAtivarModoSupressao;

    // Start is called before the first frame update
    void Start()
    {
        this.podeAtirar = true;
        this.modoSupressao = false;
        this.capacidade = 45;
        this.danoPequena = 16;
        this.danoMedio = 12;
        this.danoLongo = 8;
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
                    int sorteio = (int)Random.Range(5, 7);
                    StartCoroutine(Disparar(sorteio, 1, alvo));
                }
                else
                {
                    StartCoroutine(Disparar(45, 6, alvo));
                    this.AtivarOuDesativarHabilidade();
                }
            }
        }
    }

    private IEnumerator Disparar(int vezes, int tempoPraVoltarAtirar, PlayerBehaviour alvo)
    {
        for (int i = 0; i < vezes; i++)
        {
            if (this.capacidade > 0)
            {
                Instantiate(this.projetil, this.canoDaArma.position, this.canoDaArma.rotation);
                this.capacidade--;
                yield return new WaitForSeconds(0.2f);
            }
        }
        yield return new WaitForSeconds(tempoPraVoltarAtirar);
        this.podeAtirar = true;
    }

    public override void AtivarOuDesativarHabilidade()
    {
        if (this.modoSupressao && this.voltarAtivarModoSupressao)
        {
            this.modoSupressao = false;
            StartCoroutine(Esperar(2.0f));
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
        this.capacidade = 45;
        this.podeAtirar = true;
    }
}
