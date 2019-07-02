﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] enemytospawn;
    public Vector3 spawnValue;

    public float spawnWait;
    public float spawnLongWait;
    public float spawnShortWait;
    public int startWait;
    public bool stop;

    int randomEnemy; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    float getRandomValue()
    {
        return Random.Range(-15, 15);
    }
    
    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnShortWait, spawnLongWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {
            randomEnemy = Random.Range(0, enemytospawn.Length);

            Vector3 spawnposition = new Vector3(Random.Range(-spawnValue.y, spawnValue.y), 1, Random.Range(-spawnValue.x, spawnValue.x));

            GameObject enemyMissile = Instantiate(enemytospawn[randomEnemy], spawnposition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            enemyMissile.GetComponent<Rigidbody>().AddForce(new Vector3(getRandomValue(), -15, 0), ForceMode.VelocityChange);

            yield return new WaitForSeconds(spawnWait);
        }

        //GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0,0), ForceMode.Acceleration);
    }
}