
using UnityEngine;
using System.Collections;

public class P38Behaviour : WeaponBehaviour {


    // Use this for initialization
    new void Start() {
        this.limitesDeDisparos = 1;
        this.capacidade = 8;
    }

    // Update is called once per frame
    new void Update() {

        if (Input.GetButtonDown("Fire1")) {
            this.Atirar();
        }

        if (this.disparados < this.limitesDeDisparos && this.capacidade > 0)
        {
            this.podeAtirar = true;
        }

        if (this.capacidade == 0) {
            StartCoroutine(Recarregar());
        }
    }

    public override void Atirar() {
        if (this.podeAtirar) {
            Instantiate(this.projetil, this.canoDaArma.position, this.canoDaArma.rotation);
            this.disparados++;
            this.capacidade--;
            this.podeAtirar = false;
            StartCoroutine(EsperarPraAtirar());
        }
    }

    public override IEnumerator Recarregar() {
        yield return new WaitForSeconds(3);
        this.capacidade = 8;
    }

    private IEnumerator EsperarPraAtirar() {
        int tempo = (int)Random.Range(3, 6);
        yield return new WaitForSeconds(tempo);
        this.podeAtirar = true;
        this.disparados = 0;
    }
}
