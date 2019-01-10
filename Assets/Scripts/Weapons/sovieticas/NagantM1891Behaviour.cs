using UnityEngine;
using System.Collections;

public class NagantM1891Behaviour : WeaponBehaviour
{
    // Start is called before the first frame update
    new void Start()
    {
        this.podeAtirar = true;
        this.capacidade = 7;
        this.danoPequena = 22;
        this.danoMedio = 16.5f;
        this.danoLongo = 11;
    }

    // Update is called once per frame
    new void Update()
    {
        /*if (Input.GetButtonDown("Fire1")) {
            this.Atirar();
        }*/

        if (this.capacidade == 0)
        {
            this.podeAtirar = false;
            StartCoroutine(this.Recarregar());
        }
    }

    public void Atirar()
    {
        if (this.podeAtirar)
        {
            this.podeAtirar = false;
            Instantiate(this.projetil, this.canoDaArma.position, this.canoDaArma.rotation);
            this.capacidade--;
            StartCoroutine(this.EsperarPraAtirar());
        }
    }

    public override void Atirar(PlayerBehaviour alvo)
    {
        if (this.podeAtirar)
        {
            this.podeAtirar = false;
            float distancia = Vector3.Distance(alvo.transform.position, this.canoDaArma.transform.position);
            this.CalcularDano(distancia);
            alvo.LevaDano(this.dano);
            this.capacidade--;
            StartCoroutine(this.EsperarPraAtirar());
        }
    }

    private IEnumerator EsperarPraAtirar()
    {
        int tempo = Random.Range(4, 7);
        yield return new WaitForSeconds(tempo);
        this.podeAtirar = true;
    }

    public override IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(3);
        this.podeAtirar = true;
    }

    private void CalcularDano(float distancia)
    {
        if (distancia >= 2 && distancia <= 4)
        {
            this.dano = this.danoPequena;
        }
        else if (distancia > 4 && distancia <= 7)
        {
            this.dano = this.danoMedio;
        }
        else if (distancia > 7 && distancia <= 10)
        {
            this.dano = this.danoLongo;
        }
    }
}