using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnidadeInfantaria : MonoBehaviour
{
    public List<PlayerBehaviour> soldados;
    public bool destruida;

    // Start is called before the first frame update
    void Start() {
        this.soldados = new List<PlayerBehaviour>();
        this.soldados.AddRange(this.GetComponentsInChildren<PlayerBehaviour>());
        this.destruida = false;

    }

    // Update is called once per frame
    void Update() {
        if (this.destruida) {
            Destroy(this.gameObject);
        }

        this.Verifica();
    }

    private void Verifica()
    {
        foreach (PlayerBehaviour soldado in this.soldados)
        {
            if (soldado != null)
            {
                this.destruida = false;
                break;
            }
            else
            {
                this.destruida = true;
            }
        }
    }

    public List<PlayerBehaviour> GetSoldados() {
        return this.soldados;
    }

    private void OnMouseDown() {
        
    }
}