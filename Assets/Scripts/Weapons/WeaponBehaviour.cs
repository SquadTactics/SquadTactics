using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 */
public abstract class WeaponBehaviour : MonoBehaviour
{

    // Bullet.
    public BulletsBehaviour projetil;
    public Transform canoDaArma;

    protected float danoPequena;
    protected float danoMedio;
    protected float danoLongo;
    protected float dano;

    // Speed that the gun can re-shoot.
    protected float velocidade;

    // Capacity of weapon.
    protected int capacidade;

    // Penetration of weapon.
    protected int penetracao;

    // Tempo para arma voltar a atirar depois de ser totalmente descarregada(Tempo de reload).
    protected float tempo;

    // Verifica se a arma pode disparar.
    protected bool podeAtirar;
    
    /// <summary>
    ///    Method that will treat the weapon logic of instantiating the bullet.
    /// </summary>
    public abstract void Atirar(PlayerBehaviour alvo);

    /// <summary>
    ///     Method that deals with the logic of reloading the weapon.
    /// </summary>
    public abstract IEnumerator Recarregar();
}
