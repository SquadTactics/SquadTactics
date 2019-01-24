using UnityEngine;
using System.Collections;

public class NagantM1891Behaviour : WeaponBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.podeAtirar = true;
        this.capacidade = 7;
        this.danoPequena = 22;
        this.danoMedio = 16.5f;
        this.danoLongo = 11;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.capacidade == 0)
        {
            this.podeAtirar = false;
            StartCoroutine(this.Recarregar());
        }
    }

    public override void Atirar(PlayerBehaviour alvo)
    {
        if (this.podeAtirar)
        {
            this.podeAtirar = false;
            Instantiate(this.projetil, this.canoDaArma.transform.position, this.canoDaArma.rotation);
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
        this.capacidade = 7;
    }
}