using UnityEngine;
using System.Collections;

public class NagantM1891Behaviour : WeaponBehaviour
{

    public GameObject baioneta;
    public bool atacarComBaioneta;
    
    // Start is called before the first frame update
    void Start()
    {
        this.podeAtirar = true;
        this.capacidade = 7;
        this.danoPequena = 22;
        this.danoMedio = 16.5f;
        this.danoLongo = 11;
        this.atacarComBaioneta = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("W"))
        {
            this.baioneta.SetActive(true);
            this.podeAtirar = false;
            this.atacarComBaioneta = true;
        }
        

    }

    public override void Atirar(PlayerBehaviour alvo)
    {
        if (this.podeAtirar)
        {
            if (this.capacidade == 0)
            {
                StartCoroutine(Recarregar());
            } else
            {
                float distancia = Vector3.Distance(this.canoDaArma.transform.position, alvo.transform.position);
                if (distancia > 20)
                {
                    return;
                }
                else
                {
                    this.podeAtirar = false;
                    Instantiate(this.projetil, this.canoDaArma.transform.position, this.canoDaArma.rotation);
                    this.capacidade--;
                    StartCoroutine(this.EsperarPraAtirar());
                }
            }
        }
        this.podeAtirar = false;
    }

    private IEnumerator EsperarPraAtirar()
    {
        int tempo = Random.Range(4, 8);
        yield return new WaitForSeconds(tempo);
        this.podeAtirar = true;
    }

    public override IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(3);
        this.capacidade = 7;
        this.podeAtirar = true;
    }
}