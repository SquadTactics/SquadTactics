using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Mp40Behaviour : WeaponBehaviour {

    // O modo em que a arma estar.
    public bool modoFull;

    // Start is called before the first frame update
    void Start()
    {
        this.capacidade = 32;
        this.podeAtirar = true;
        this.modoFull = false;
        this.danoPequena = 10;
        this.danoMedio = 7;
        this.danoLongo = 5;
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
                if (!this.modoFull)
                {
                    int sorteio = (int)Random.Range(4, 7);
                    StartCoroutine(Disparar(sorteio, 1, alvo));
                }
                else
                {
                    if (this.capacidade <= 24)
                    {
                        StartCoroutine(this.Recarregar());
                    }
                    StartCoroutine(Disparar(32, 5, alvo));
                    this.modoFull = false;
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
                Instantiate(this.projetil, this.canoDaArma.transform.position, this.canoDaArma.rotation);
                this.capacidade--;
                yield return new WaitForSeconds(0.2f);
            }
        }
        yield return new WaitForSeconds(tempoPraVoltarAtirar);
        this.podeAtirar = true;
    }

    public override void AtivarOuDesativarHabilidade()
    {
        if (this.modoFull)
        {
            this.modoFull = false;
        }
        else
        {
            this.modoFull = true;
        }
    }

    public override IEnumerator Recarregar() {
        yield return new WaitForSeconds(3);
        this.capacidade = 32;
        this.podeAtirar = true;
    }
}
