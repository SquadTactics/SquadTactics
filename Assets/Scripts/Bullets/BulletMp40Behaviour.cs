using UnityEngine;
using System.Collections;

public class BulletMp40Behaviour : BulletsBehaviour {

    // Use this for initialization
    new void Start() {
        this.timeToLive = 5;
        this.velocity = 1;
        Destroy(this.gameObject, this.timeToLive);
    }

    // Update is called once per frame
    new void Update() {
        transform.Translate(Vector3.forward * this.velocity * Time.deltaTime);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision) {
        if (collision.other.CompareTag("parede")) {
            Destroy(collision.other);
        }
    }
}