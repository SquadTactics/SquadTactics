using UnityEngine;
using System.Collections;

public class DP28Behaviour : WeaponBehaviour {

    private bool modoSupressao;

    // Start is called before the first frame update
    new void Start() {
        this.podeAtirar = true;
        this.modoSupressao = false;
        this.capacidade = 45;
    }

    // Update is called once per frame
    new void Update() {

        if (Input.GetButtonDown("Fire1")) {
            this.Atirar();
        }

        if (this.capacidade == 0) {
            this.podeAtirar = false;
            StartCoroutine(Recarregar());
        }

        if (Input.GetButtonDown("W")) {
            this.AtivarModoSupressao();
        }

        if (Input.GetButtonDown("Q")) {
            this.AtivarModoNormal();
        }
    }

    public override void Atirar() {
        if (this.podeAtirar) {
            this.podeAtirar = false;
            if (!this.modoSupressao) {
                int sorteio = (int)Random.Range(5, 7);
                StartCoroutine(Disparar(sorteio, 1));
            } else {
                StartCoroutine(Disparar(45, 6));
            }
        }
    }

    private IEnumerator Disparar(int vezes, int tempoPraVoltarAtirar)
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

    public override IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(3);
        this.capacidade = 45;
        this.podeAtirar = true;
    }

    public void AtivarModoSupressao() {
        this.modoSupressao = true;
    }

    public void AtivarModoNormal() {
        this.modoSupressao = false;
    }
}
