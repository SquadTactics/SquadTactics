using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NagantBehaviour : WeaponBehaviour
{

    private float shootAgain;

    // Start is called before the first frame update
    new void Start() {
        this.limitesDeDisparos = 1;
        this.shootAgain = 4;
        this.capacidade = 7;
    }

    // Update is called once per frame
    new void Update() {

        if (this.disparados >= this.limitesDeDisparos) {
            this.velocidade += Time.deltaTime;
            if (this.velocidade >= this.shootAgain) {
                this.velocidade = 0;
                this.disparados = 0;
            }
        }
    }

    public override void Atirar() {
        if (this.capacidade > 0) {
            if (this.disparados < this.limitesDeDisparos) {
                Instantiate(this.projetil, this.canoDaArma.position, this.canoDaArma.rotation);
                this.disparados++;
                this.capacidade--;
            }
        }
    }

    public override IEnumerator Recarregar()
    {
        yield return new WaitForSeconds(0);
    }
}
