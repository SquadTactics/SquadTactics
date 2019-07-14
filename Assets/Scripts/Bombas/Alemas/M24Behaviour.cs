using UnityEngine;
using System.Collections;

public class M24Behaviour : BombaBehaviour
{

    // Use this for initialization
    void Start()
    {
        this.dano = 45;
        this.alcance = 0.3f;
        this.tempo = 30;
        this.tempoStun = 3;
        this.cooldown = 30;
        this.penetracao = 1;
        this.GetComponent<Rigidbody>().AddForce(new Vector3(this.transform.position.x, 8.5f, 8.5f * transform.localScale.z), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
