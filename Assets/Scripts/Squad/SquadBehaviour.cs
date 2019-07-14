using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sargento;
    public GameObject grupo1Prefab;
    public GameObject grupo2Prefab;
    GameObject time1;
    GameObject time2;
    void Start()
    {
        this.GetComponent<MovimentoBehaviour>().podeMover = true;
        time1 = Instantiate(grupo1Prefab, new Vector3((sargento.transform.position.x) - 10, sargento.transform.position.y, sargento.transform.position.z), Quaternion.identity) as GameObject;
        time2 = Instantiate(grupo2Prefab, new Vector3((sargento.transform.position.x) + 10, sargento.transform.position.y, sargento.transform.position.z), Quaternion.identity) as GameObject;
        time1.AddComponent<MovimentoBehaviour>();
        time2.AddComponent<MovimentoBehaviour>();
        //pelotao1.transform.parent = sargento.transform;
        //pelotao2.transform.parent = sargento.transform;
        //pelotao3.transform.parent = sargento.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.GetComponent<MovimentoBehaviour>().podeMover = true;
            time1.GetComponent<MovimentoBehaviour>().podeMover = false;
            time2.GetComponent<MovimentoBehaviour>().podeMover = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)){
            this.GetComponent<MovimentoBehaviour>().podeMover = false;
            time1.GetComponent<MovimentoBehaviour>().podeMover = true;
            time2.GetComponent<MovimentoBehaviour>().podeMover = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)){
            this.GetComponent<MovimentoBehaviour>().podeMover = false;
            time1.GetComponent<MovimentoBehaviour>().podeMover = false;
            time2.GetComponent<MovimentoBehaviour>().podeMover = true;
        }
    }
}
