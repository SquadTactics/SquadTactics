using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletsBehaviour : MonoBehaviour {

    protected float velocity;
    protected float timeToLive;

    // Start is called before the first frame update
    protected void Start() {

    }

    // Update is called once per frame
    protected void Update() {
        
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (!(collision.gameObject.tag == "projetil"))
        {
            Debug.Log("OKOK");
            Destroy(this.gameObject);
        }
    }
}
