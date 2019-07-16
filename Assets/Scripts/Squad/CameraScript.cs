using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public UnityEngine.Transform sargentoPos;
    private Vector3 offset;
    public PlayerBehaviour sargento;

    // Start is called before the first frame update
    void Start()
    {
        this.sargento = GetComponentInChildren<PlayerBehaviour>();
        offset = transform.position - this.sargentoPos.position;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void LateUpdate()
    {
        transform.position = this.sargentoPos.position + offset;
    }
}
