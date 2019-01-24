using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class PlayerBehaviour : MonoBehaviour {

    public WeaponBehaviour weapon;

    public float vida;
    public PlayerBehaviour alvo;
    public bool modoAtaque;

    protected float _velocidade;
    protected float _girar;

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
