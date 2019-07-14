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

    protected float alcance;
    protected float precisao;

    // Speed that the gun can re-shoot.
    protected float velocidade;

    // Capacity of weapon.
    protected int capacidade;

    // Penetration of weapon.
    protected float penetracao;

    // Tempo para arma voltar a atirar depois de ser totalmente descarregada(Tempo de reload).
    protected float tempo;
    protected float tempoEntreDisparos;

    // Verifica se a arma pode disparar.
    protected bool podeAtirar;
    
    /// <summary>
    ///    Method that will treat the weapon logic of instantiating the bullet.
    /// </summary>
    public abstract void Atirar(PlayerBehaviour alvo);

    public abstract void AtivarOuDesativarHabilidade();

    /// <summary>
    ///     Method that deals with the logic of reloading the weapon.
    /// </summary>
    public abstract IEnumerator Recarregar();
}
