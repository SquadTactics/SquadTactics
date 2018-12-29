using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NagantBehaviour : WeaponBehaviour
{

    private float time;
    private float shootAgain;

    // Start is called before the first frame update
    void Start() {
        this.shootingLimits = 1;
        this.shootAgain = 4;
        this.capacity = 7;
    }

    // Update is called once per frame
    void Update() {

        if (this.fired >= this.shootingLimits) {
            this.velocity += Time.deltaTime;
            if (this.velocity >= this.shootAgain) {
                this.velocity = 0;
                this.fired = 0;
            }
        }
    }

    public override void Fire() {
        if (this.capacity > 0) {
            if (this.fired < this.shootingLimits) {
                Instantiate(this.bullet, this.gunBarrel.position, this.gunBarrel.rotation);
                this.fired++;
                this.capacity--;
            }
        }
    }

    public override void Reload() {
        throw new System.NotImplementedException();
    }
}
