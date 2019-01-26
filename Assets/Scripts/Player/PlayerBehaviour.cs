using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class PlayerBehaviour : MonoBehaviour {

    [Header("Ataque")]
    public WeaponBehaviour weapon;
    public PlayerBehaviour alvo;

    [Header("Status")]
    protected float vida;
    protected bool modoAtaque;

    [Header("Movimentação")]
    protected NavMeshAgent agente;
    protected Vector3 destino;


    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public abstract void LevaDano(float dano);

    public void SetAlvo(PlayerBehaviour alvo)
    {
        this.alvo = alvo;
    }

    public float GetVida()
    {
        return this.vida;
    }

    public abstract void Movimentar(Vector3 position);

    public abstract void Rotacionar(Vector3 position);
}
