using System.Runtime.Serialization;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Transform[] spawnPoints;
    [SerializeField]private Spawn spawn;
    private float nextSpawnTime = 0f;
    public void StartWave()
    {
        nextSpawnTime = Time.time;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawn.spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        int objectIndex = Random.Range(0, spawn.objectPrefabs.Length);
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(spawn.objectPrefabs[objectIndex], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
    }
}
