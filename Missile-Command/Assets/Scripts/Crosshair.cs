using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Transform anchor;
    public float sensitivity = 15f;
    Vector3 position;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDickhead = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        position = position + moveDickhead * sensitivity;

        transform.position = position;
    }
}
