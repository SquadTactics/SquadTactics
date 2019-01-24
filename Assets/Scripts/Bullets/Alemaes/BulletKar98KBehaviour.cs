using UnityEngine;
using System.Collections;

public class BulletKar98KBehaviour : BulletsBehaviour {

    // Use this for initialization
    void Start()
    {
        this.velocidade = 15;
        this.origem = this.transform.position;
        this.danoPequena = 25;
        this.danoMedio = 18.75f;
        this.danoLongo = 12.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * this.velocidade * Time.deltaTime);
        distancia = Vector3.Distance(this.transform.position, this.origem);
        if (distancia > 10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "landser")
        {
            float distancia = Vector3.Distance(collision.gameObject.GetComponent<LandserBehaviour>().transform.position, this.origem);
            Debug.Log("Distancia: " + distancia);
            this.CalcularDano(distancia);
            collision.gameObject.GetComponent<LandserBehaviour>().LevaDano(this.dano);
            Debug.Log("Dano: " + this.dano);
            Destroy(this.gameObject);
        }
    }

    protected override void CalcularDano(float distancia)
    {
        if (distancia >= 2 && distancia <= 4.5)
        {
            this.dano = this.danoPequena;
        }
        else if (distancia > 4.5 && distancia <= 7)
        {
            this.dano = this.danoMedio;
        }
        else if (distancia > 7 && distancia <= 10)
        {
            this.dano = this.danoLongo;
        }
    }
}