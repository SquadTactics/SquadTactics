using UnityEngine;
using System.Collections;

public class BulletNagantM1891ScBehaviour : BulletsBehaviour {

    // Use this for initialization
    void Start() {
        this.origem = this.transform.position;
        this.velocidade = 15;
        this.danoPequena = 30;
        this.danoMedio = 22.5f;
        this.danoLongo = 15;
    }

    // Update is called once per frame
    void Update() {
        this.transform.Translate(Vector3.forward * this.velocidade * Time.deltaTime);
        distancia = Vector3.Distance(this.transform.position, this.origem);
        if (distancia > 25)
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
        if (distancia >= 2 && distancia <= 10)
        {
            this.dano = this.danoPequena;
        }
        else if (distancia > 10 && distancia <= 19)
        {
            this.dano = this.danoMedio;
        }
        else if (distancia > 19 && distancia <= 25)
        {
            this.dano = this.danoLongo;
        }
    }
}
