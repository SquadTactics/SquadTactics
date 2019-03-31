using UnityEngine;
using System.Collections;

public class BaionetaMNBehaviour : MonoBehaviour
{

    public float dano;
    public float alcance;
    public float penetracao;

    // Use this for initialization
    void Start()
    {
        this.dano = 30;
        this.alcance = 2;
        this.penetracao = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Atacar(PlayerBehaviour alvo)
    {
        float distancia = Vector3.Distance(this.transform.position, alvo.transform.position);
        if (distancia < 2)
        {
            // TODO Animação de atacar com a baioneta(Coronhada).
            alvo.LevaDano(this.dano);
        }
    }
}
