using UnityEngine;
using UnityEditor;
using System;

public class BulletDP28Behaviour : BulletsBehaviour {

    // Use this for initialization
    void Start()
    {
        this.origem = this.transform.position;
        this.velocidade = 15;
        this.danoPequena = 16;
        this.danoMedio = 12;
        this.danoLongo = 8;
    }

    // Update is called once per frame
    void Update() {
        this.transform.Translate(Vector3.forward * this.velocidade * Time.deltaTime);
        float distancia = Vector3.Distance(this.transform.position, this.origem);
        if (distancia > 22) {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision) {
        if (collision.gameObject.tag == "landser") {
            float distancia = Vector3.Distance(collision.gameObject.GetComponent<PlayerBehaviour>().transform.position, this.origem);
            this.CalcularDano(distancia);
            collision.gameObject.GetComponent<PlayerBehaviour>().LevaDano(this.dano);
            Destroy(this.gameObject);
        }
    }

    protected override void CalcularDano(float distancia) {
        if (distancia >= 2 && distancia <= 9)
        {
            this.dano = this.danoPequena;
        }
        else if (distancia > 9 && distancia <= 15)
        {
            this.dano = this.danoMedio;
        }
        else if (distancia > 15 && distancia <= 22)
        {
            this.dano = this.danoLongo;
        }
    }
}