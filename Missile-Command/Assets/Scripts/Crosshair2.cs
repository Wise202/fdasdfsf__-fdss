using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair2 : MonoBehaviour
{
    public Transform anchor2;
    public float sensitivity2 = 1f;
    Vector3 position2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDickhead2 = new Vector3(Input.GetAxis("p2Horizontal"), Input.GetAxis("p2Vertical"), 0);
        position2 = position2 + moveDickhead2 * sensitivity2;

        transform.position = position2;
    }
}
