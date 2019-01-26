using UnityEngine;
using System.Collections;
using System;

public class BulletNagantM1891Behaviour : BulletsBehaviour {

    // Use this for initialization
    void Start() {
        this.origem = this.transform.position;
        this.velocidade = 15;
        this.danoPequena = 22;
        this.danoMedio = 16.5f;
        this.danoLongo = 11;
    }

    // Update is called once per frame
    void Update() {
        this.transform.Translate(Vector3.forward * this.velocidade * Time.deltaTime);
        distancia = Vector3.Distance(this.transform.position, this.origem);
        if (distancia > 20) {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision) {
        if (collision.gameObject.tag == "landser")
        {
            float distancia = Vector3.Distance(collision.gameObject.GetComponent<PlayerBehaviour>().transform.position, this.origem);
            this.CalcularDano(distancia);
            collision.gameObject.GetComponent<PlayerBehaviour>().LevaDano(this.dano);
            Destroy(this.gameObject);
        }
    }

    protected override void CalcularDano(float distancia) {
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
