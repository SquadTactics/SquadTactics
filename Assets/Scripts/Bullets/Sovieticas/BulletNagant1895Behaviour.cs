using UnityEngine;
using System.Collections;

public class BulletNagant1895Behaviour : BulletsBehaviour
{

    // Use this for initialization
    new void Start() {
        this.velocidade = 1;
        this.danoPequena = 10;
        this.danoMedio = 7.5f;
        this.danoLongo = 5;
    }

    // Update is called once per frame
    new void Update() {
        this.transform.Translate(Vector3.forward * this.velocidade * Time.deltaTime);
        distancia = Vector3.Distance(this.transform.position, this.origem);
        if (distancia > 4)
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
            this.CalculaDano(distancia);
            collision.gameObject.GetComponent<PlayerBehaviour>().LevaDano(this.dano);
            Debug.Log("Dano: " + this.dano);
            Destroy(this.gameObject);
        }
    }

    private void CalculaDano(float distancia)
    {
        if (distancia >= 2 && distancia <= 2.5)
        {
            this.dano = this.danoPequena;
        }
        else if (distancia > 2.5 && distancia <= 3.5)
        {
            this.dano = this.danoMedio;
        }
        else if (distancia > 3.5 && distancia <= 4)
        {
            this.dano = this.danoLongo;
        }
    }
}
