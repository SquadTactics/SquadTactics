using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimentoBehaviour : MonoBehaviour
{
    public bool podeMover = false;
    public NavMeshAgent agent;
    public bool movendo = false;
    Vector3 posicaoClick;
    //Vector3 olharParaAlvo;
    //Quaternion playerRaiz;
    //float velocidadeRotacao = 5f;
    //float velocidadeMovimento = 3f;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (podeMover == true)
        {
            if (Input.GetMouseButton(1))
            {
                SetPosicaoClick();
            }
        }
        if (movendo)
        {
            Mover();
        }
    }
    void SetPosicaoClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.CompareTag("relevo"))
            {
                posicaoClick = hit.point;
                //olharParaAlvo = new Vector3(posicaoClick.x - transform.position.x, transform.position.y, posicaoClick.z - transform.position.z);
                //playerRaiz = Quaternion.LookRotation(olharParaAlvo);
                movendo = true;
            }
            else { movendo = false; }
        }
    }
    void Mover()
    {
        agent.SetDestination(posicaoClick);
        agent.isStopped = false;
        //transform.rotation = Quaternion.Slerp(transform.rotation, playerRaiz, velocidadeRotacao * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, posicaoClick, velocidadeMovimento * Time.deltaTime);
        //if (transform.position == posicaoClick)
        //{
        //    movendo = false;
        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        movendo = false;
    }
}
