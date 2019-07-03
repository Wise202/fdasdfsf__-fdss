using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUfo : MonoBehaviour
{
    public GameObject uFo; 
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnUFO();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnUFO()
    {
        Instantiate(uFo, new Vector3(-0, -0, -11), Quaternion.identity);
    }
}
