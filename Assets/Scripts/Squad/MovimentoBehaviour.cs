using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBehaviour : MonoBehaviour
{
    public bool podeMover = false;
    public bool movendo = false;
    Vector3 posicaoClick;
    Vector3 olharParaAlvo;
    Quaternion playerRaiz;
    float velocidadeRotacao = 5f;
    float velocidadeMovimento = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (podeMover == true)
        {
            if (Input.GetMouseButton(0))
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
        if(Physics.Raycast(ray, out hit, 1000))
        {
            posicaoClick = hit.point;
            olharParaAlvo = new Vector3(posicaoClick.x - transform.position.x, transform.position.y, posicaoClick.z - transform.position.z);
            playerRaiz = Quaternion.LookRotation(olharParaAlvo);
            if(Vector3.Distance(this.transform.position, posicaoClick) <= 1.2)
            {
                movendo = false;
            }
            else { movendo = true; }
        }
    }
    void Mover()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRaiz, velocidadeRotacao * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, posicaoClick, velocidadeMovimento * Time.deltaTime);
        if (transform.position == posicaoClick)
        {
            movendo = false;
        }
    }
}
