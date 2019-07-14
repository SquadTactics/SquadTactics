using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public UnityEngine.Transform sargentoPos;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - sargentoPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        transform.position = sargentoPos.position + offset;
    }
}
