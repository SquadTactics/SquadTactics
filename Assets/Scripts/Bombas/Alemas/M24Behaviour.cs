using UnityEngine;
using System.Collections;

public class M24Behaviour : BombaBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.dano = 50;
        this.tempoStun = 2;
        this.cooldown = 30;
        this.penetracao = 1;
        this.GetComponent<Rigidbody>().AddForce(new Vector3(this.transform.position.x, 8.5f, 8.5f * transform.localScale.z), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
