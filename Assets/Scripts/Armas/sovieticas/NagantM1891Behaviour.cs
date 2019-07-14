using UnityEngine;
using System.Collections;

public class NagantM1891Behaviour : WeaponBehaviour
{

    public BaionetaMNBehaviour baioneta;
    public bool atacarComBaioneta;
    
    // Start is called before the first frame update
    void Start()
    {
        this.podeAtirar = true;
        this.dano = 23;
        this.alcance = 0.8f;
        this.capacidade = 5;
        this.tempo = 5;
        this.tempoEntreDisparos = 5;
        this.precisao = 0.8f;

        this.danoPequena = 22;
        this.danoMedio = 16.5f;
        this.danoLongo = 11;
        this.atacarComBaioneta = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("W"))
        {
            this.baioneta.gameObject.SetActive(true);
            this.podeAtirar = false;
            this.atacarComBaioneta = true;
        }
        
        if (Input.GetButtonDown("Q"))
        {
            this.baioneta.gameObject.SetActive(false);
            this.atacarComBaioneta = false;
            this.podeAtirar = true;
        }*/

        if (Input.GetMouseButton(0))
        {
            this.Atirar(new LandserBehaviour());
        }

    }

    public override void Atirar(PlayerBehaviour alvo)
    {
        if (atacarComBaioneta)
        {
            this.atacarComBaioneta = false;
            this.baioneta.Atacar(alvo);
            StartCoroutine(Esperar());
        }
        if (this.podeAtirar)
        {
            if (this.capacidade == 0)
            {
                StartCoroutine(Recarregar());
            } else
            {
                //float distancia = Vector3.Distance(this.canoDaArma.transform.position, alvo.transform.position);
                this.podeAtirar = false;
                Instantiate(this.projetil, this.canoDaArma.transform.position, this.canoDaArma.rotation);
                this.capacidade--;
                StartCoroutine(this.EsperarPraAtirar());
            }
        }
        this.podeAtirar = false;
    }

    private IEnumerator EsperarPraAtirar()
    {
        float tempo = this.tempoEntreDisparos;
        yield return new WaitForSeconds(tempo);
        this.podeAtirar = true;
    }

    private IEnumerator Esperar()
    {
        yield return new WaitForSeconds(this.tempo);
        this.atacarComBaioneta = true;
    }

    public override IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(this.tempo);
        this.capacidade = 5;
        this.podeAtirar = true;
    }

    public override void AtivarOuDesativarHabilidade()
    {
        if (this.atacarComBaioneta)
        {
            this.baioneta.gameObject.SetActive(false);
            this.atacarComBaioneta = false;
            this.podeAtirar = true;
        } else
        {
            this.baioneta.gameObject.SetActive(true);
            this.podeAtirar = false;
            this.atacarComBaioneta = true;
        }
    }
}