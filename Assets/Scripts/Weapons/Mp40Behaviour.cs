using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mp40Behaviour : WeaponBehaviour {

    public float temp;

    // Start is called before the first frame update
    new void Start() {
        this.shootingLimits = 4;
        this.shootAgain = 1;
        this.capacity = 32;
    }

    // Update is called once per frame
    new void Update() {

        if (this.capacity == 0) {
            if (this.temp < 3) {
                this.temp += Time.deltaTime;
            } else if (temp >= 3) {
                this.temp = 0;
                this.capacity = 32;
            }
        }

        if (this.fired > this.shootingLimits) {
            this.velocity += Time.deltaTime;
            if (this.velocity >= this.shootAgain) {
                this.fired = 0;
                this.velocity = 0;
            }
        }

        if (Input.GetButtonDown("W")) {
            this.OnAbilityFullAuto();
        }

        if (Input.GetButtonDown("Q")) {
            this.OnNormal();
        }
    }

    public override void Fire() {
        if (this.capacity > 0) {
            if (this.fired <= this.shootingLimits) {
                Instantiate(this.bullet, this.transform.position, this.transform.rotation);
                this.fired++;
                this.capacity--;
            }
        } else {
            //
        }
    }

    public override void Reload() {
        
    }

    public void OnAbilityFullAuto() {
        this.shootingLimits = 32;
        this.shootAgain = 5;
        this.velocity = 0;
    }

    public void OnNormal() {
        this.shootingLimits = 4;
        this.shootAgain = 1;
    }

}
