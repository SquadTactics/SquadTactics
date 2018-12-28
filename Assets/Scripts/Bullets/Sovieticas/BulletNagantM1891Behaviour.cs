using UnityEngine;
using System.Collections;

public class BulletNagantM1891Behaviour : BulletsBehaviour
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
}
