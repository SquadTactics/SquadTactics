using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletsBehaviour : MonoBehaviour {

    public float velocidade;
    public float tempoDeVida;

    protected float danoPequena;
    protected float danoMedio;
    protected float danoLongo;
    protected float distancia;

    protected float dano;

    protected Vector3 origem;

    public PlayerBehaviour alvo;

    // Start is called before the first frame update
    protected void Start() {

    }

    // Update is called once per frame
    protected void Update() {
        
    }
}
