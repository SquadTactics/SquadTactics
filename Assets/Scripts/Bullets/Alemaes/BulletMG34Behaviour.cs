using UnityEngine;
using System.Collections;

public class BulletMG34Behaviour : BulletsBehaviour {

    // Use this for initialization
    void Start()
    {
        this.velocidade = 15;
        this.origem = this.transform.position;
        this.danoPequena = 18;
        this.danoMedio = 13.5f;
        this.danoLongo = 9;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * this.velocidade * Time.deltaTime);
        distancia = Vector3.Distance(this.transform.position, this.origem);
        if (distancia > 12)
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
        if (distancia >= 2 && distancia <= 5)
        {
            this.dano = this.danoPequena;
        }
        else if (distancia > 5 && distancia <= 8.5)
        {
            this.dano = this.danoMedio;
        }
        else if (distancia > 8.5 && distancia <= 12)
        {
            this.dano = this.danoLongo;
        }
    }
}