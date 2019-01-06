using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Mp40Behaviour : WeaponBehaviour {

    // Temp the gun will take to load
    public float time;
    private float shootAgain;
    private bool podeAtirar;

    // Start is called before the first frame update
    new void Start() {
        this.shootAgain = 1;
        this.capacity = 32;
        this.podeAtirar = true;
    }

    // Update is called once per frame
    new void Update() {

        if (this.capacity == 0) {
            if (this.time < 3) {
                this.time += Time.deltaTime;
            } else {
                this.time = 0;
                this.capacity = 32;
            }
        }

        if (Input.GetButtonDown("Fire1") && this.podeAtirar) {
            this.podeAtirar = false;
            int sorteio = (int)Random.Range(4, 7);
            Debug.Log("Balas: " + sorteio);
            StartCoroutine(Disparar(sorteio));
        }

        if (Input.GetButtonDown("W")) {
            this.OnAbilityFullAuto();
        }

        if (Input.GetButtonDown("Q")) {
            this.OnNormal();
        }
    }

    public override void Fire() {
        int sorteio = (int)Random.Range(4, 7);
        Debug.Log("Balas: " + sorteio);
        StartCoroutine(Disparar(sorteio));
    }

    private IEnumerator Disparar(int vezes) {
        for (int i = 0; i < vezes; i++)
        {
            if (this.capacity > 0)
            {
                Instantiate(this.bullet, this.gunBarrel.position, this.gunBarrel.rotation);
                this.capacity--;
                yield return new WaitForSeconds(0.2f);
            }
        }
        Debug.Log("Capacidade: " + this.capacity);
        yield return new WaitForSeconds(1);
        this.podeAtirar = true;
    }

    private IEnumerator EsperarPraAtirar() {
        yield return new WaitForSeconds(1);
        this.podeAtirar = true;
    }

    public override void Reload() {
        if (this.capacity == 0) {
            if (this.time < 3) {
                this.time += Time.deltaTime;
            }
            else {
                this.time = 0;
                this.capacity = 32;
            }
        }
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
