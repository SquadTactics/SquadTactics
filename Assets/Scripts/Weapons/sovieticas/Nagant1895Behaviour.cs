using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nagant1895Behaviour : WeaponBehaviour
{
    // Start is called before the first frame update
    new void Start()
    {
        this.podeAtirar = true;
        this.capacidade = 7;
    }

    // Update is called once per frame
    new void Update()
    {

        if (this.capacidade > 0)
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

    public override void Atirar(PlayerBehaviour alvo)
    {
        throw new System.NotImplementedException();
    }
}
