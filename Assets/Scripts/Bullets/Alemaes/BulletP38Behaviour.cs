using UnityEngine;
using System.Collections;
using System;

public class BulletP38Behaviour : BulletsBehaviour {

    // Use this for initialization
    new void Start() {
        this.origem = this.transform.position;
        this.velocidade = 15;
        this.danoPequena = 12;
        this.danoMedio = 9;
        this.danoLongo = 6;
    }

    // Update is called once per frame
    new void Update() {
        transform.Translate(Vector3.forward * this.velocidade * Time.deltaTime);
        float distancia = Vector3.Distance(transform.position, this.origem);
        // Corrigir alcance para 4.
        if (distancia > 4)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision) {
        if (collision.gameObject.tag == "landser") {
            float distancia = Vector3.Distance(collision.gameObject.GetComponent<LandserBehaviour>().transform.position, this.origem);
            Debug.Log("Distancia: " + distancia);
            this.CalculaDano(distancia);
            if (distancia > 4) {
                Destroy(this.gameObject);
            } else {
                collision.gameObject.GetComponent<LandserBehaviour>().LevaDano(this.dano);
                Debug.Log("OKOK");
                Destroy(this.gameObject);
            }
        }
    }

    private void CalculaDano(float distancia) {
        if (distancia >= 2 && distancia < 3) {
            this.dano = this.danoPequena;
        } else if (distancia >= 3 && distancia <= 3.5f) {
            this.dano = this.danoMedio;
        } else if (distancia > 3.5f && distancia <= 4) {
            this.dano = this.danoLongo;
        }
    }
}