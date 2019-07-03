using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterBlast : MonoBehaviour
{
    public GameObject[] scatterTargets;
    public GameObject scatterBlast;
    int scatterPoints = 5;

    void Start()
    {
        scatterTargets = new GameObject[scatterPoints];
        for (int i = 0; i < scatterPoints; i++)
        {
            GameObject blast = Instantiate(scatterBlast, new Vector3((float)i, 1, 0), Quaternion.identity) as GameObject;
            blast.transform.localScale = Vector3.one;
            scatterTargets[i] = blast;
        }
    }

}
