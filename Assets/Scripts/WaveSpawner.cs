using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    #region Public fields
    public float timeBetweenWaves = 5f;
    public Text waveCountdownText;
    public Transform enemyPrefab;
    public Transform spawnPoint;

    #endregion

    #region Private fields
    private float countdown = 2f;
    private int waveIndex = 0;

    #endregion

    #region Private methods
    private void Update()
    {
        if(countdown<=0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    private IEnumerator SpawnWave()
    {
        ++waveIndex;
        ++PlayerStats.Rounds;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    #endregion

}