using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Enemy Wave Config")]

//scriptable object instead of mono behavior to make objects like this 
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBtwnSpawns = .5f;
    [SerializeField] float randomSpawnFactor = .3f;
    [SerializeField] int enemyNumber = 5;
    [SerializeField] float moveSpeed = 3f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public List<Transform> GetWaypoints() 
    {
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints; 
    }
    public float GetTimeBtwnSpawns() { return timeBtwnSpawns; }
    public float GetRandomSpawnFactor() { return randomSpawnFactor; }
    public int GetEnemyNumber() { return enemyNumber; }
    public float GetMoveSpeed() { return moveSpeed; }
}
