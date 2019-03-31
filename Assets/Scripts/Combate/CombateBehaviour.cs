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

    public static void EscolheAlvos(UnidadeInfantaria unidade1, UnidadeInfantaria unidade2)
    {
        UnidadeInfantaria temp = unidade1;
        if (unidade2.GetSoldados().ToArray().Length == 6)
        {
            unidade1 = unidade2;
            unidade2 = temp;
        }
        int i = 0;
        unidade1.SetInimiga(unidade2);
        unidade2.SetInimiga(unidade1);
        foreach (PlayerBehaviour s1 in unidade1.GetSoldados())
        {
            if (i >= 4)
            {
                int ultimo = unidade2.GetSoldados().ToArray().Length - 1;
                s1.SetAlvo(unidade2.GetSoldados()[ultimo]);
            } else
            {
                foreach (PlayerBehaviour s2 in unidade2.GetSoldados())
                {
                    if (!s1.TemAlvo())
                    {
                        if (!s2.TemAlvo())
                        {
                            s1.SetAlvo(s2);
                            s2.SetAlvo(s1);
                            break;
                        }
                    }
                }
            }
            i++;
        }

        /*foreach (PlayerBehaviour s1 in unidade1.GetSoldados())
        {
            int j = 0;
            foreach (PlayerBehaviour s2 in unidade2.GetSoldados())
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
        }*/
    }
}
