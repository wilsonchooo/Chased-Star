using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

    int currentScore;
    [SerializeField] bool onlyOnce = true;



    // Start is called before the first frame update
    // Start is IEnumerator so it can be a coroutine
    IEnumerator Start()
    {
        
        //while loping is true keep spawning all waves
        do
        {

            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);

        
    }

    private void Update()
    {
        currentScore = FindObjectOfType<GamePlayUI>().returnScore();
        if(currentScore >= 200 && onlyOnce == true)
        {
            FindObjectOfType<BossSpawner>().SpawnBoss();
        }

    }

    public void noMoreBosses()
    {
        onlyOnce = false;
        looping = false;
    }


    private IEnumerator SpawnAllWaves()
    {
        //for every waveIndex, up until the amount of waveConfigs in the list, increment waveIndex by 1
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetEnemyNumber(); enemyCount++) {
            //each enemy created will be stored to new enemy
            var newEnemy = 
            Instantiate(
                waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            //pass in the waveconfig in this script to EnemyPathing
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBtwnSpawns());
        }
    }
}
