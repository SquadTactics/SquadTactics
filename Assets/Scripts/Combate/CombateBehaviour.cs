using UnityEngine;
using System.Collections;
using System;

public class CombateBehaviour : MonoBehaviour
{

    public UnidadeInfantaria unidade1;
    public UnidadeInfantaria unidade2;

    // Use this for initialization
    void Start() {
        this.EscolheAlvos();
    }

    // Update is called once per frame
    void Update() {

    }

    private void EscolheAlvos()
    {
        int i = 0;
        
        foreach (PlayerBehaviour s1 in this.unidade1.GetSoldados())
        {
            int j = 0;
            foreach (PlayerBehaviour s2 in this.unidade2.GetSoldados())
            {
                if (i == j)
                {
                    s1.SetAlvo(s2);
                    s2.SetAlvo(s1);
                    i++;
                    break;
                }
                else
                {
                    j++;
                }
            }
        }
    }
}
