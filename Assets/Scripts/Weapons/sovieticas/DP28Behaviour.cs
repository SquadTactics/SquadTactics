using UnityEngine;
using System.Collections;

public class DP28Behaviour : WeaponBehaviour {

    private float shootAgain;

    // Start is called before the first frame update
    new void Start() {
        this.limitesDeDisparos = 6;
        this.shootAgain = 1;
        this.capacidade = 45;
    }

    // Update is called once per frame
    new void Update() {
        if (this.capacidade == 0) {
            if (this.tempo < 3) {
                this.tempo += Time.deltaTime;
            }
            else {
                this.tempo = 0;
                this.capacidade = 32;
            }
        }

        if (this.disparados > this.limitesDeDisparos) {
            this.velocidade += Time.deltaTime;
            if (this.velocidade >= this.shootAgain) {
                this.disparados = 0;
                this.velocidade = 0;
            }
        }

        if (Input.GetButtonDown("W")) {
            this.OnAbilityFullAuto();
        }

        if (Input.GetButtonDown("Q")) {
            this.OnNormal();
        }
    }

    public override void Atirar() {
        if (this.capacidade > 0) {
            if (this.disparados <= this.limitesDeDisparos) {
                Instantiate(this.projetil, this.canoDaArma.position, this.canoDaArma.rotation);
                this.disparados++;
                this.capacidade--;
            }
        }
    }

    public override void Recarregar()
    {

    }

    public void OnAbilityFullAuto()
    {
        this.limitesDeDisparos = 45;
        this.shootAgain = 6;
        this.velocidade = 0;
    }

    public void OnNormal()
    {
        this.limitesDeDisparos = 6;
        this.shootAgain = 1;
    }
}
