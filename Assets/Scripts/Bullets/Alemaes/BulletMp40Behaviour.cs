using UnityEngine;
using System.Collections;

public class BulletMp40Behaviour : BulletsBehaviour {

    // Use this for initialization
    new void Start() {
        this.tempoDeVida = 1.05f;
        this.velocidade = 13;
        Destroy(this.gameObject, this.tempoDeVida);
    }

    // Update is called once per frame
    new void Update() {
        transform.Translate(Vector3.forward * this.velocidade * Time.deltaTime);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "landser")
        {
            collision.gameObject.GetComponent<LandserBehaviour>().LevaDano(20);
        }
    }
}