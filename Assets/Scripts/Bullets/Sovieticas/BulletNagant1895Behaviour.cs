using UnityEngine;
using System.Collections;

public class BulletNagant1895Behaviour : BulletsBehaviour
{

    // Use this for initialization
    void Start() {
        this.velocidade = 15;
        this.danoPequena = 10;
        this.danoMedio = 7.5f;
        this.danoLongo = 5;
    }

    // Update is called once per frame
    void Update() {
        this.transform.Translate(Vector3.forward * this.velocidade * Time.deltaTime);
        distancia = Vector3.Distance(this.transform.position, this.origem);
        if (distancia > 10)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "landser")
        {
            float distancia = Vector3.Distance(collision.gameObject.GetComponent<PlayerBehaviour>().transform.position, this.origem);
            Debug.Log("Distancia: " + distancia);
            this.CalcularDano(distancia);
            collision.gameObject.GetComponent<PlayerBehaviour>().LevaDano(this.dano);
            Debug.Log("Dano: " + this.dano);
            Destroy(this.gameObject);
        }
    }

    protected override void CalcularDano(float distancia)
    {
        if (distancia >= 2 && distancia <= 4)
        {
            this.dano = this.danoPequena;
        }
        else if (distancia > 4 && distancia <= 7)
        {
            this.dano = this.danoMedio;
        }
        else if (distancia > 7 && distancia <= 10)
        {
            this.dano = this.danoLongo;
        }
    }
}
