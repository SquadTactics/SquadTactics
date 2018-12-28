using UnityEngine;
using System.Collections;

public class BulletNagantBehaviour : BulletsBehaviour
{

    // Use this for initialization
    void Start() {
        this.timeToLive = 5;
        this.velocity = 1;
        Destroy(this.gameObject, this.timeToLive);
    }

    // Update is called once per frame
    void Update() {
        this.transform.Translate(Vector3.forward * this.velocity * Time.deltaTime);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision) {
        // TODO
        // Vamos colocar os objetos em tags(ou layers) e então iremos fazer 
        // a verificação aqui e então farremos a lógica necessária.
    }
}
