using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveScript : MonoBehaviour
{
    //So th way that this workks is that, it be spawning in the object that spawn the missiles.
    //Once all the objects that spawns the missiles dissappear, then the new wave will come.

    //This enum will make sure that the wave will work in the order it meant to go.
    public enum SpawnState { Spawning, Waiting, Countdown };
    private SpawnState state = SpawnState.Countdown;

    //Setting up the how each wave will work.
    [System.Serializable]
    public class EnemyWave
    {
        public string name;
        public Transform[] spawnEnemyMissile;
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

    public Text waveText;

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

        if (enemySpawnCountDown <= 0)
        {
            if (state != SpawnState.Spawning)
            {
                StartCoroutine(SpawningMissiles(waves[nextWave]));
            }
        }
        else
        {
            enemySpawnCountDown -= Time.deltaTime;
        }

        waveText.text = wavenumber.ToString();
    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectsWithTag("EnemyBase").Length == 0)
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
            Time.timeScale = 0;
            Debug.Log("All waves completed! Game is Complete!");
        }
        else
        {
            nextWave++;
            wavenumber++;
        }
    }

    IEnumerator SpawningMissiles(EnemyWave wave)
    {
        Debug.Log("Spawning new wave " + wave.name);

        state = SpawnState.Spawning;

        for (int i = 0; i < wave.count; i++)
        {
            EnemyWave missile = waves[i];
            SpawnMissile(missile.spawnEnemyMissile[Random.Range(0, missile.spawnEnemyMissile.Length)]);
            yield return new WaitForSeconds(1f / wave.rate);
            SpawnMissile(missile.spawnEnemyMissile[Random.Range(0, missile.spawnEnemyMissile.Length)]);
            yield return new WaitForSeconds(1.5f / wave.rate);
            SpawnMissile(missile.spawnEnemyMissile[Random.Range(0, missile.spawnEnemyMissile.Length)]);
            yield return new WaitForSeconds(2f / wave.rate);
        }

        state = SpawnState.Waiting;

        yield break;
    }

    void SpawnMissile(Transform missileSpawn)
    {
        Instantiate(missileSpawn);
    }
}
