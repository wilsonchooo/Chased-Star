using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    //configuration parameters 
    //[SerializeField] 
    WaveConfig waveConfig;
    List<Transform> waypoints;
    //[SerializeField] float moveSpeed = 2f;
    int waypointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        //go to the first position in the list of waypoints 
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame 
    void Update()
    {
        EnemyMove();
    }

    //need to get info from the waveconfig
    public void SetWaveConfig(WaveConfig waveConfig)
    {
        //waveconfig from EnemySpawner is used on the right side of =
        //this. is used to refer to the waveConfig that was serialized (dont read this line)
        this.waveConfig = waveConfig;
    }

    private void EnemyMove()
    {
        //if the enemy has not yet reached the waypoint, move there
        //Count is used for length 
        if (waypointIndex <= waypoints.Count - 1)
        {
            //where you want to go and how fast you want to get there 
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementPerFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            //move, current - target - speed
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementPerFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
