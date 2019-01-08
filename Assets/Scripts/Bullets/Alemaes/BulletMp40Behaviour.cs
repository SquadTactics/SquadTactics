using UnityEngine;
using System.Collections;

public class BulletMp40Behaviour : BulletsBehaviour {

    // Use this for initialization
    new void Start() {
        this.velocidade = 15;
        this.origem = this.transform.position;
        this.danoPequena = 10;
        this.danoMedio = 7;
        this.danoLongo = 5;
    }

    // Update is called once per frame
    new void Update() {
        transform.Translate(Vector3.forward * this.velocidade * Time.deltaTime);
        float distancia = Vector3.Distance(transform.position, this.origem);
        if (distancia > 6)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision) {
        if (collision.gameObject.tag == "landser") {
            float distancia = Vector3.Distance(collision.gameObject.GetComponent<LandserBehaviour>().transform.position, this.origem);
            Debug.Log("Distancia a: " + collision.gameObject.GetComponent<LandserBehaviour>().transform.position);
            Debug.Log("Distancia: " + distancia);
            this.CalculaDano(distancia);
            if (distancia > 6) {
                Destroy(this.gameObject);
            } else {
                collision.gameObject.GetComponent<LandserBehaviour>().LevaDano(this.dano);
                Debug.Log("Dano: " + this.dano);
                Destroy(this.gameObject);
            }
        }
    }

    private void CalculaDano(float distancia) {
        if (distancia >= 2 && distancia <= 3) {
            this.dano = this.danoPequena;
        } else if (distancia > 3 && distancia <= 5) {
            this.dano = this.danoMedio;
        } else if (distancia > 5 && distancia <= 6) {
            this.dano = this.danoLongo;
        }
    }
}