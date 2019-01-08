using UnityEngine;
using UnityEditor;
using System;

public class BulletDP28Behaviour : BulletsBehaviour {

    // Use this for initialization
    new void Start()
    {
        this.origem = this.transform.position;
        this.velocidade = 15;
        this.danoPequena = 16;
        this.danoMedio = 12;
        this.danoLongo = 8;
    }

    // Update is called once per frame
    new void Update() {
        this.transform.Translate(Vector3.forward * this.velocidade * Time.deltaTime);
        float distancia = Vector3.Distance(this.transform.position, this.origem);
        if (distancia > 12) {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision) {
        if (collision.gameObject.tag == "landser") {
            float distancia = Vector3.Distance(collision.gameObject.GetComponent<LandserBehaviour>().transform.position, this.origem);
            this.CalcularDano(distancia);
            if (distancia > 12) {
                Destroy(this.gameObject);
            } else {
                collision.gameObject.GetComponent<LandserBehaviour>().LevaDano(this.dano);
                Destroy(this.gameObject);
            }
        }
    }

    private void CalcularDano(float distancia) {
        if (distancia >= 2 && distancia <= 4) {
            this.dano = this.danoPequena;
        } else if (distancia > 4 && distancia <= 8) {
            this.dano = this.danoMedio;
        } else if (distancia > 8 && distancia <= 12) {
            this.dano = this.danoLongo;
        }
    }
}