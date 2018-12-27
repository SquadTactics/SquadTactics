using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mp40Behaviour : WeaponBehaviour {

    // Start is called before the first frame update
    new void Start() {
        this.isFire = true;
    }

    // Update is called once per frame
    new void Update() {
        if (!isFire) {
            this.velocity += Time.deltaTime;
            if (this.velocity >= 4) {
                this.isFire = true;
                this.velocity = 0;
            }
        }
    }

    public override void Fire() {
        if (this.isFire) {
            Instantiate(this.bullet, this.transform.position, this.transform.rotation);
            this.isFire = false;
        }
    }

    public override void Reload() {
        throw new System.NotImplementedException();
    }
}
