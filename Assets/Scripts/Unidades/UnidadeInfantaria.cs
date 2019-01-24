using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnidadeInfantaria : MonoBehaviour
{
    public List<PlayerBehaviour> soldados;
    public bool destruida;
    public bool selecionada;
    private NavMeshAgent agente;
    private Vector3 destino;

    // Start is called before the first frame update
    void Start() {
        this.soldados = new List<PlayerBehaviour>();
        this.agente = this.GetComponent<NavMeshAgent>();
        this.soldados.AddRange(this.GetComponentsInChildren<PlayerBehaviour>());
        this.destruida = false;
        this.selecionada = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.selecionada = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (selecionada)
            {
                this.selecionada = false;
                StartCoroutine(this.Mover(Input.mousePosition));
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (this.selecionada)
            {
                this.selecionada = false;
                foreach (var soldado in this.soldados)
                {
                    soldado.Rotacionar(Input.mousePosition);
                }

            }
        }

        if (this.destruida) {
            Destroy(this.gameObject);
        }

        this.Verifica();
    }

    private IEnumerator Mover(Vector3 pos)
    {
        if (!this.VerificarColisao(pos))
        {
            Debug.Log("OKOK");
            Vector3 aux = new Vector3(pos.x, pos.y - 50, pos.z);

            float i = 50;
            int cont = 1;
            foreach (PlayerBehaviour soldado in this.GetSoldados())
            {
                if (cont <= 2)
                {
                    soldado.Movimentar(pos);
                    pos.x += i;
                }
                else
                {
                    soldado.Movimentar(aux);
                    aux.x += i;
                }
                cont++;
                yield return new WaitForSeconds(1);
            }
        }
    }

    private bool VerificarColisao(Vector3 pos)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(pos), out hit))
        {
            if (hit.collider.CompareTag("Unidade"))
            {
                CombateBehaviour.EscolheAlvos(this, hit.collider.gameObject.GetComponent<UnidadeInfantaria>());
                return true;
            }
        }
        return false;
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
}