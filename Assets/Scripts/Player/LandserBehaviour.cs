using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandserBehaviour : PlayerBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.vida = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.vida <= 0) {
            Destroy(this.gameObject, 1);
        }
    }

    public void LevaDano(float dano) {
        this.vida -= dano;
        Debug.Log(this.vida);
    }
}
