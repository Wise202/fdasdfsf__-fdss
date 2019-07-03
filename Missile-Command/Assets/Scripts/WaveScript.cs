using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveScript : MonoBehaviour
{
    //This enum will make sure that the wave will work in the order it meant to go.
    public enum SpawnState { Spawning, Waiting, Countdown };
    private SpawnState state = SpawnState.Countdown;

    //Setting up the how each wave will work.
    public class EnemyWave
    {
        public string name;
        public int count;
        public float rate;
    }

    public EnemyWave[] waves;
    private int nextWave = 0;
    public int wavenumber = 0;

    //The time it will take for when the wave ends to the next wave.
    public float enemySpawnDelay;
    public float enemySpawnCountDown;
    public float searchCountDown = 1f;

    public RandomSpawn[] missileSpawn = new RandomSpawn[24];

    // Start is called before the first frame update
    void Start()
    {
        enemySpawnCountDown = enemySpawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.Waiting)
        {
            //This is to check that all the enemy missile is gone.
            if (!EnemyIsAlive())
            {
                NewWave();
                return;
            }
            else
            {
                return;
            }
        }
    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectsWithTag("EnemyMissile").Length == 0)
            {
                return false;
            }
        }
        return true;
    }

    void NewWave()
    {
        Debug.Log("All Missile Gone. Wave Complete");

        state = SpawnState.Countdown;
        enemySpawnCountDown = enemySpawnDelay;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("All waves completed! Time to Loop");
        }
        else
        {
            nextWave++;
        }
    }

    IEnumerator SpawningMissiles(EnemyWave wave)
    {
        Debug.Log("Spawning new wave " + wave.name);

        state = SpawnState.Spawning;

        for (int i = 0; i < wave.count; i++)
        {
            EnemyWave missile = waves[i];
            SpawnMissile();
            yield return new WaitForSeconds(1f / wave.rate);
            SpawnMissile();
            yield return new WaitForSeconds(1.5f / wave.rate);
            SpawnMissile();
            yield return new WaitForSeconds(2f / wave.rate);
        }

        state = SpawnState.Waiting;

        yield break;
    }

    void SpawnMissile()
    {
        missileSpawn[Random.Range(0, 23)].waitSpawner();
    }
}
