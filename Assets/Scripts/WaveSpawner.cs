using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

  [System.Serializable]
  public class Wave {
    public Enemy[] enemies;
    public int count;
    public float timeBetweenSpawns;
  }

  public Wave[] waves;
  public Transform[] spawnPoints;
  public float timeBetweenWaves;

  public GameObject boss;
  public Transform bossSpawnPoint;

  private Wave currentWave;
  private int currentWaveIndex;
  private Transform player;
  private bool finishedSpawning;


  private void Start() {
    player = GameObject.FindGameObjectWithTag("Player").transform;
    StartCoroutine(StartNextWave(currentWaveIndex));
  }

  IEnumerator StartNextWave(int index) {
    Debug.Log("Next Wave in " + timeBetweenWaves + "Seconds");
    yield return new WaitForSeconds(timeBetweenWaves);
    StartCoroutine(SpawnWave(index));
  }

  IEnumerator SpawnWave(int index) {
    currentWave = waves[index];
    for (int i = 0; i < currentWave.count; i++) {
      if (player == null) {
        yield break;
      }

      Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
      Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
      Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);

      finishedSpawning = i == currentWave.count - 1;

      yield return new WaitForSeconds(currentWave.timeBetweenSpawns);
    }
  }

  private void Update() {
    if (finishedSpawning && GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
      finishedSpawning = false;
      if (currentWaveIndex + 1 < waves.Length) {
        currentWaveIndex++;
        StartCoroutine(StartNextWave(currentWaveIndex));
      } else {
        GameObject BossSpawn = Instantiate(boss, bossSpawnPoint.position, bossSpawnPoint.rotation);
      }
    }
  }
}
