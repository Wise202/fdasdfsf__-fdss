using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMissile : MonoBehaviour
{
    public Vector3 mousePos;
    public Vector3 deathPos;
    // Start is called before the first frame update
    void Awake()
    {
       // deathPos = transform.position;
        mousePos = Input.mousePosition;
        transform.position = mousePos;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Explosion_Point")
        {
            Debug.Log("Hey");
        }
    }

}
