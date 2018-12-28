using UnityEngine;
using System.Collections;

public class NagantM1891ScopedBehaviour : WeaponBehaviour
{
    private float time;
    private float shootAgain;

    // Use this for initialization
    void Start() {
        this.shootingLimits = 1;
        this.shootAgain = 7;
        this.capacity = 5;
    }

    // Update is called once per frame
    void Update() {

        if (this.fired >= this.shootingLimits) {
            this.velocity += Time.deltaTime;
            if (this.velocity >= this.shootAgain) {
                this.fired = 0;
                this.velocity = 0;
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
