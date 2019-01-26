using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Mp40Behaviour : WeaponBehaviour {

    // O modo em que a arma estar.
    private bool modoFull;

    private PlayerBehaviour alvo;

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

        if (Input.GetButtonDown("W")) {
            this.AtivarModoFull();
        }

        if (Input.GetButtonDown("Q")) {
            this.AtivarModoNormal();
        }

        /*if (this.capacidade == 0) {
            this.podeAtirar = false;
            StartCoroutine(Recarregar());
        }*/
    }
    
    public override void Atirar(PlayerBehaviour alvo)
    {
        if (this.podeAtirar)
        {
            this.podeAtirar = false;
            if (!this.modoFull)
            {
                Instantiate(this.projetil, this.canoDaArma.transform.position, this.canoDaArma.rotation);
                this.capacidade--;
                int sorteio = (int)Random.Range(4, 7);
                StartCoroutine(Disparar(sorteio, 1, alvo));
            }
            else
            {
                StartCoroutine(Disparar(32, 5, alvo));
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
            } else
            {
                yield return new WaitForSeconds(3);
                this.capacidade = 32;
            }
        }
        yield return new WaitForSeconds(tempoPraVoltarAtirar);
        this.podeAtirar = true;
    }

    public override IEnumerator Recarregar() {
        yield return new WaitForSeconds(3);
        this.capacidade = 32;
        this.podeAtirar = true;
    }

    public void AtivarModoFull() {
        this.modoFull = true;
    }

    public void AtivarModoNormal() {
        this.modoFull = false;
    }
}
