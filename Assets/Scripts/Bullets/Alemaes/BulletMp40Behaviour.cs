using UnityEngine;
using System.Collections;

public class BulletMp40Behaviour : BulletsBehaviour {

    // Use this for initialization
    void Start() {
        this.timeToLive = 10;
        this.velocity = 1;
        Destroy(this.gameObject, this.timeToLive);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.forward * this.velocity * Time.deltaTime);
    }
}