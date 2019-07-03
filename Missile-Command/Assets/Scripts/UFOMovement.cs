using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMovement : MonoBehaviour
{
    public GameObject[] uFo;
    public float spawnMin = 1f;
    public float spawnMax = 1f; 
   
    // Start is called before the first frame update
    void Start()
    {
        RandomSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time, 5), transform.position.y, transform.position.z);
    }

    void RandomSpawn()
    {
        Instantiate(uFo[Random.Range(0, uFo.GetLength(0))], transform.position, Quaternion.identity);
        Invoke("Spawn", Random.Range(spawnMin, spawnMax));
    }


}
