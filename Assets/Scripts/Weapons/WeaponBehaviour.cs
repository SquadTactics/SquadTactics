using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehaviour : MonoBehaviour {

    public BulletsBehaviour bullet;

    protected float damageP;
    protected float damageM;
    protected float damageL;

    protected float velocity;

    protected bool isFire;

    protected int capacity;
    protected int penetration;

    // Start is called before the first frame update
    protected void Start() {

    }

    // Update is called once per frame
    protected void Update() {

    }
    
    public abstract void Fire();

    public abstract void Reload();
}
