using UnityEngine;
using System.Collections;

public class BulletP38Behaviour : BulletsBehaviour {

    // Use this for initialization
    new void Start() {
        this.tempoDeVida = 5;
        this.velocidade = 1;
        Destroy(this.gameObject, this.tempoDeVida);
    }

    // Update is called once per frame
    new void Update() {
        transform.Translate(Vector3.forward * this.velocidade * Time.deltaTime);
    }
}
