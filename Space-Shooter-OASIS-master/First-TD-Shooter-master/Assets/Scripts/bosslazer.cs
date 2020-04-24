using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosslazer : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer>=2)
        {

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //collision.gameObject.GetComponent<Player>().health -= 1;
    }
}
