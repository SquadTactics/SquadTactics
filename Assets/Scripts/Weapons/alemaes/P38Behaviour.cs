
using UnityEngine;
using System.Collections;

public class P38Behaviour : WeaponBehaviour {


    // Use this for initialization
    new void Start()
    {
        this.limitesDeDisparos = 1;
        this.capacidade = 8;
        this.danoPequena = 12;
        this.danoMedio = 9;
        this.danoLongo = 6;
    }

    // Update is called once per frame
    new void Update()
    {

        /*if (Input.GetButtonDown("Fire1")) {
            this.Atirar();
        }*/

        if (this.disparados < this.limitesDeDisparos && this.capacidade > 0)
        {
            this.podeAtirar = true;
        }

        if (this.capacidade == 0) {
            StartCoroutine(Recarregar());
        }
    }

    public void Atirar() {
        if (this.podeAtirar) {
            Instantiate(this.projetil, this.canoDaArma.position, this.canoDaArma.rotation);
            this.disparados++;
            this.capacidade--;
            this.podeAtirar = false;
            StartCoroutine(EsperarPraAtirar());
        }
    }

    public override void Atirar(PlayerBehaviour alvo) {
        float distancia = Vector3.Distance(alvo.transform.position, this.canoDaArma.transform.position);
        if (this.podeAtirar) {
            this.podeAtirar = false;
            this.CalculaDano(distancia);
            alvo.LevaDano(this.dano);
            this.disparados++;
            this.capacidade--;
            StartCoroutine(EsperarPraAtirar());
        }
    }

    public override IEnumerator Recarregar() {
        yield return new WaitForSeconds(3);
        this.capacidade = 8;
    }

    private IEnumerator EsperarPraAtirar() {
        int tempo = (int)Random.Range(3, 5);
        yield return new WaitForSeconds(tempo);
        this.podeAtirar = true;
        this.disparados = 0;
    }

    private void CalculaDano(float distancia) {
        if (distancia >= 2 && distancia < 3) {
            this.dano = this.danoPequena;
        } else if (distancia >= 3 && distancia <= 3.5f) {
            this.dano = this.danoMedio;
        } else if (distancia > 3.5f && distancia <= 4) {
            this.dano = this.danoLongo;
        }
    }
}
