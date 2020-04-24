using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] GameObject bossPrefab;
    [SerializeField] GameObject location;
    [SerializeField] int timeBeforeBoss = 1;

    // Start is called before the first frame update
    void Start()
    {
       // SpawnBoss();
        
            //Instantiate(bossPrefab, location.transform.position, Quaternion.identity);
        
    }

    public void SpawnBoss()
    {

        Instantiate(bossPrefab, location.transform.position, Quaternion.identity);
        //Debug.Log("wowowow");
       // yield return new WaitForSeconds(timeBeforeBoss);
        FindObjectOfType<EnemySpawner>().noMoreBosses();
        
        
        
        
        //remember to add 8 seconds for john's boss music
    }

}
