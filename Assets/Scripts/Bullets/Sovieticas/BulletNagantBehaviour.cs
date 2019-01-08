using UnityEngine;
using System.Collections;

public class BulletNagantBehaviour : BulletsBehaviour
{

    // Use this for initialization
    new void Start() {
        this.velocidade = 1;
    }

    // Update is called once per frame
    new void Update() {
        this.transform.Translate(Vector3.forward * this.velocidade * Time.deltaTime);
    }
}
