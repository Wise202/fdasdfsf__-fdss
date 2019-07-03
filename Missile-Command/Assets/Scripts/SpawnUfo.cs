using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUfo : MonoBehaviour
{
    public enum UFOState { Spawning, Waiting };
    public UFOState state = UFOState.Spawning;

    public GameObject uFo;
    public float Instantiationtimer = 5f;

    public GameObject spawnedUFO;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (state == UFOState.Spawning)
        {
            SpawnUFO();
        }
        else if (state == UFOState.Waiting)
        {
            //step 2: check if the SpawnedUFO variable is empty, using a null check

            //step 3: if the spawnedUFO variable is empty, change the UFO state to spawning
        }
    }

    void SpawnUFO()
    {

        Instantiationtimer -= Time.deltaTime;

        if(Instantiationtimer <= 0)
        {
            
            //Step 1: assign the new ufo created below to the spawnedUFO variable
            Instantiate(uFo, new Vector3(-0, -0, -11), Quaternion.identity);
            Instantiationtimer = 5f;
            state = UFOState.Waiting;

        }

    }

    
}
