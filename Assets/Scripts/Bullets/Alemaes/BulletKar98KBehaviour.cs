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
        Physics.IgnoreLayerCollision(13, 12);
        Physics.IgnoreLayerCollision(13, 11);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * this.velocidade * Time.deltaTime);
        distancia = Vector3.Distance(this.transform.position, this.origem);
        if (distancia > 20)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Debug.Log("OKOK");
            float distancia = Vector3.Distance(collision.gameObject.GetComponent<PlayerBehaviour>().transform.position, this.origem);
            this.CalcularDano(distancia);
            collision.gameObject.GetComponent<PlayerBehaviour>().LevaDano(this.dano);
            Destroy(this.gameObject);
        }
    }

    protected override void CalcularDano(float distancia)
    {
        if (distancia >= 2 && distancia <= 8)
        {
            this.dano = this.danoPequena;
        }
        else if (distancia > 8 && distancia <= 14)
        {
            this.dano = this.danoMedio;
        }
        else if (distancia > 14 && distancia <= 20)
        {
            this.dano = this.danoLongo;
        }
    }
}