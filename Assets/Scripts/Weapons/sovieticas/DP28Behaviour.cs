using UnityEngine;
using System.Collections;

public class DP28Behaviour : WeaponBehaviour {

    // Temp the gun will take to load
    public float time;
    private float shootAgain;

    // Start is called before the first frame update
    void Start() {
        this.shootingLimits = 6;
        this.shootAgain = 1;
        this.capacity = 45;
    }

    // Update is called once per frame
    void Update() {
        if (this.capacity == 0) {
            if (this.time < 3) {
                this.time += Time.deltaTime;
            }
            else {
                this.time = 0;
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
                Instantiate(this.bullet, this.gunBarrel.position, this.gunBarrel.rotation);
                this.fired++;
                this.capacity--;
            }
        }
    }

    public override void Reload()
    {

    }

    public void OnAbilityFullAuto()
    {
        this.shootingLimits = 45;
        this.shootAgain = 6;
        this.velocity = 0;
    }

    public void OnNormal()
    {
        this.shootingLimits = 6;
        this.shootAgain = 1;
    }
}
