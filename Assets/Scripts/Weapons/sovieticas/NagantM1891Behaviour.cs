using UnityEngine;
using System.Collections;

public class NagantM1891Behaviour : WeaponBehaviour
{
    private float shootAgain;

    // Use this for initialization
    new void Start() {
        this.limitesDeDisparos = 1;
        this.shootAgain = 5;
        this.capacidade = 5;
    }

    // Update is called once per frame
    new void Update() {

        if (this.disparados >= this.limitesDeDisparos) {
            this.velocidade += Time.deltaTime;
            if (this.velocidade >= this.shootAgain) {
                this.disparados = 0;
                this.velocidade = 0;
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
