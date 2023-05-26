using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    //VARIABLES
    [SerializeField] private Wave[] waves;
    [SerializeField] private float timeBetweenWaves = 3f;
    [SerializeField] private float waveCountdown = 0;
    private SpawnState state = SpawnState.COUNTING;
    private int currentWave;
    //REREFENCES
    [SerializeField] private Transform[] spawners;
    [SerializeField] private List<CharacterStats> enemyList;
    private bool spawnWaves = true;
    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        currentWave = 0;
    }

    private void Update()
    {
        if (!spawnWaves)
            return;

        if (state == SpawnState.WAITING)
        {
            if (!EnemiesAreDead())
                return;
            else
                //COMPLETE THE WAVE
                CompleteWave();
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                //Spawn zombies
                StartCoroutine(SpawnWave(waves[currentWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }
    private IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;
        Debug.Log("Spawning Wave: " + currentWave);
        for (int i = 0; i < wave.enemiesAmount; i++)
        {
            SpawnZombie(wave.enemy);
            yield return new WaitForSeconds(wave.delay);
        }

        state = SpawnState.WAITING;

        yield break;
    }
    private void SpawnZombie(GameObject enemy)
    {
        int randomInt = Random.RandomRange(1, spawners.Length);
        Transform randomSpawner = spawners[randomInt];

        GameObject newEnemy = Instantiate(enemy, randomSpawner.position, randomSpawner.rotation);
        CharacterStats newEnemyStats = newEnemy.GetComponent<CharacterStats>();

        enemyList.Add(newEnemyStats);
    }

    private bool EnemiesAreDead()
    {
        int i = 0;
        foreach (CharacterStats enemy in enemyList)
        {
            if (enemy.IsDead())
                i++;
            else
                return false;
        }
        return true;
    }

    private void CompleteWave()
    {
        Debug.Log("Wave Completed");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (currentWave + 1 > waves.Length - 1)
        {
            currentWave = 0;
            Debug.Log("All waves complete");
            spawnWaves = false;
        }
        else
        {
            currentWave++;
        }
    }
}
