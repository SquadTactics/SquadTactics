using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletsBehaviour : MonoBehaviour {

    public float velocidade;
    
    protected float distancia;
    protected float dano;
    protected float danoPequena;
    protected float danoMedio;
    protected float danoLongo;

    protected Vector3 origem;

    protected abstract void CalcularDano(float distancia);

}
