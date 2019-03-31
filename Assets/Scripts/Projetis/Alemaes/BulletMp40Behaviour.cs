using UnityEngine;
using System.Collections;
using System;

public class BulletMp40Behaviour : BulletsBehaviour {

    // Use this for initialization
    void Start()
    {
        this.velocidade = 15;
        this.origem = this.transform.position;
        this.danoPequena = 10;
        this.danoMedio = 7;
        this.danoLongo = 5;
        Physics.IgnoreLayerCollision(13, 12);
        Physics.IgnoreLayerCollision(13, 11);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.forward * this.velocidade * Time.deltaTime);
        distancia = Vector3.Distance(this.transform.position, this.origem);
        if (distancia > 12)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            float distancia = Vector3.Distance(collision.gameObject.GetComponent<PlayerBehaviour>().transform.position, this.origem);
            this.CalcularDano(distancia);
            collision.gameObject.GetComponent<PlayerBehaviour>().LevaDano(this.dano);
            Destroy(this.gameObject);
        }
    }

    protected override void CalcularDano(float distancia) {
        if (distancia >= 2 && distancia <= 5) {
            this.dano = this.danoPequena;
        } else if (distancia > 5 && distancia <= 8.5) {
            this.dano = this.danoMedio;
        } else if (distancia > 8.5 && distancia <= 12) {
            this.dano = this.danoLongo;
        }
    }
}