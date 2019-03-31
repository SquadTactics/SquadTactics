using UnityEngine;
using System.Collections;

public class StrelokBehaviour : SoldadoBehaviour
{
    public override void Skills()
    {
        if (Input.GetButtonDown("Q"))
        {
            this.weapon.AtivarOuDesativarHabilidade();
        }

        if (Input.GetButtonDown("W"))
        {
            this.ModoAgachado();
        }

        if (Input.GetButtonDown("E"))
        {
            this.AumentarVelocidadeDeCorrer();
        }

        if (Input.GetButtonDown("R"))
        {
            this.ArremessarGranada();
        }
    }
}
