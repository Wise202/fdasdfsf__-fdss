using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair3 : MonoBehaviour
{
    public Transform anchor3;
    public float sensitivity3 = 1f;
    Vector3 position3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDickhead3 = new Vector3(Input.GetAxis("p3Horizontal"), Input.GetAxis("p3Vertical"), 0);
        position3 = position3 + moveDickhead3 * sensitivity3;

        transform.position = position3;
    }
}
