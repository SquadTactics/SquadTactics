using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nagant1895Behaviour : WeaponBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.podeAtirar = true;
        this.dano = 12;
        this.alcance = 0.4f;
        this.capacidade = 7;
        this.tempo = 14;
        this.tempoEntreDisparos = 2;
        this.precisao = 0.5f;
        this.penetracao = 0.5f;


        this.danoPequena = 10;
        this.danoMedio = 7.5f;
        this.danoLongo = 5;
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
        if (this.podeAtirar)
        {
            this.podeAtirar = false;
            if (this.capacidade == 0)
            {
                StartCoroutine(Recarregar());
            } else
            {
                Debug.Log("AQUI");
                Instantiate(this.projetil, this.canoDaArma.transform.position, this.canoDaArma.rotation);
                this.capacidade--;
                StartCoroutine(this.EsperarPraAtirar());
            }
        }
    }

    public override IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(this.tempo);
        this.capacidade = 7;
        this.podeAtirar = true;
    }

    private IEnumerator EsperarPraAtirar()
    {
        yield return new WaitForSeconds(this.tempoEntreDisparos);
        this.podeAtirar = true;
    }

    public override void AtivarOuDesativarHabilidade()
    {
        // Feels :(
    }
}
