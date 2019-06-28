using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOStrafe : MonoBehaviour
{
    GameObject point1;
    GameObject point2;

    Transform point1Place;
    Transform point2Place;

    Transform target;

    float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        point1 = GameObject.FindGameObjectWithTag("Point1");
        point2 = GameObject.FindGameObjectWithTag("Point2");

        point1Place = point1.transform;
        point2Place = point2.transform;

        target = point1Place;
    }

    // Update is called once per frame
    void Update()
    {
        float fly = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target.position, fly);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point1"))
        {
            Debug.Log("Point1 booped");
            target = point2Place;
        }
        else if (other.CompareTag("Point2"))
        {
            Debug.Log("Point2 booped");
            target = point1Place;
        }

    }
}
