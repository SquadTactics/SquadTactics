using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandserBehaviour : PlayerBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        this.vida = 100;
        this.modoAtaque = true;
        this.weapon = this.GetComponentInChildren<WeaponBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.vida <= 0) {
            Destroy(this.gameObject, 1);
        }

        if (this.alvo != null) {
            this.modoAtaque = true;
        } else {
            this.modoAtaque = false;
        }

        if (this.modoAtaque) {
            if (!(this.alvo.GetVida() <= 0))
            {
                weapon.Atirar(this.alvo);
            }
        }
    }

    public override void LevaDano(float dano) {
        this.vida -= dano;
    }
}
