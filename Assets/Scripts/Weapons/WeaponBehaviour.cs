using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 */
public abstract class WeaponBehaviour : MonoBehaviour {

    // Bullet.
    public BulletsBehaviour bullet;

    // Damages.
    protected float damageLittle;
    protected float damageMedium;
    protected float damageLong;

    // Speed that the gun can re-shoot.
    protected float velocity;

    // Shots fired before velocity was reached.
    protected int fired;
    
    // Total allowed shots and then wait a while to re-shoot.
    protected int shootingLimits;

    // Capacity of weapon.
    protected int capacity;

    // Penetration of weapon.
    protected int penetration;

    public Transform gunBarrel;

    // Start is called before the first frame update
    protected void Start() {
        this.Fire();
    }

    // Update is called once per frame
    protected void Update() {
        
    }

     /// <summary>
     ///    Method that will treat the weapon logic of instantiating the bullet.
     /// </summary>
    public abstract void Fire();

    /// <summary>
    ///     Method that deals with the logic of reloading the weapon.
    /// </summary>
    public abstract void Reload();
}
