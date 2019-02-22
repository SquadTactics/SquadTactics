using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnidadeInfantaria : InfantariaBehaviour
{
    [Header("Soldados")]
    public List<PlayerBehaviour> soldados;

    public UnidadeInfantaria inimiga;

    [Header("Status")]
    public bool destruida;
    public bool selecionada;
    public bool parouDeAtacar;
    
    // Start is called before the first frame update
    void Start() {
        this.GetComponents();
        this.destruida = false;
        this.selecionada = false;
        this.parouDeAtacar = true;
    }

    // Update is called once per frame
    void Update()
    {
        // botão 1 - Seleciona a unidade do time.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.selecionada = true;
        }

        // Botão 0 do mouse - para se mover.
        if (Input.GetMouseButtonDown(0))
        {
            if (selecionada)
            {
                this.selecionada = false;
                StartCoroutine(this.Mover(Input.mousePosition));
            }
        }

        // Botão 1 do mouse - Faz a unidade selecionar mirar em algum ponto fixo do mapa.
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
        this.verificaAlvos();
    }

    private void verificaAlvos()
    {
        foreach (PlayerBehaviour soldado in this.soldados)
        {
            if (this.inimiga != null)
            {
                if (!soldado.TemAlvo())
                {
                    soldado.ProcuraAlvo(this.inimiga.GetSoldados());
                }
            }
        }
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

    public void SetInimiga(UnidadeInfantaria unidade2)
    {
        this.inimiga = unidade2;
    }

    private IEnumerator Mover(Vector3 pos)
    {
        if (!this.VerificarColisao(pos))
        {
            
            foreach (PlayerBehaviour soldado in this.GetSoldados())
            {
                soldado.Movimentar(pos);
                pos.y -= 50;
                //pos.x += 50;
                yield return new WaitForSeconds(1);
            }
                /*Vector3 aux = new Vector3(pos.x, pos.y - 50, pos.z);

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
                */
            }
    }

    private bool VerificarColisao(Vector3 pos)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(pos), out hit))
        {
            if (hit.collider.CompareTag("Unidade"))
            {
                this.inimiga = hit.collider.gameObject.GetComponent<UnidadeInfantaria>();
                CombateBehaviour.EscolheAlvos(this, hit.collider.gameObject.GetComponent<UnidadeInfantaria>());
                return true;
            }
        }
        return false;
    }

    public List<PlayerBehaviour> GetSoldados() {
        return this.soldados;
    }

    public void GetComponents()
    {
        this.soldados = new List<PlayerBehaviour>();
        this.soldados.AddRange(this.GetComponentsInChildren<PlayerBehaviour>());
    }
}