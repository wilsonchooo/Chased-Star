using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    float timer;
    float secondaryattacktimer;
    int whichattack;
    // Start is called before the first frame update
    public GameObject enemyfirepoint1;
    public GameObject enemyfirepoint2;
    public GameObject enemyfirepoint3;
    public GameObject homingbolt;
    public GameObject randombolt;
    public GameObject bolt;
    public GameObject center;
    public float radius;
    public GameObject snakeprefab;

    private bool spawned;

    private float maxhealth;
    void Start()
    {
        timer = 0;
        //vattack();
        //xattack();
        maxhealth = GetComponent<BossEnemy>().health;
        spawned = false;

    }

    void basicattack()
    {

        Instantiate(homingbolt, new Vector3(enemyfirepoint2.transform.position.x, enemyfirepoint2.transform.position.y, 0), Quaternion.identity);
        Instantiate(homingbolt, new Vector3(enemyfirepoint1.transform.position.x, enemyfirepoint1.transform.position.y, 0), Quaternion.identity);
    }

    void fire(float xpos, float ypos,int firepoint)
    {
        if(firepoint==1)
        {
            Instantiate(bolt, new Vector3(enemyfirepoint1.transform.position.x + xpos, enemyfirepoint1.transform.position.y + ypos, 0), Quaternion.identity);
        }

        if(firepoint==2)
        {
            Instantiate(bolt, new Vector3(enemyfirepoint2.transform.position.x + xpos, enemyfirepoint2.transform.position.y + ypos, 0), Quaternion.identity);
        }

    }
    void vattack(int firepoint)
    {
        
        for (float i = 0; i < 3; i += .5f)
        {
            fire(-i*radius, i * radius, firepoint);
            fire(i * radius, i * radius, firepoint);
        }
    }

    void oattack(int firepoint)
    {
        
        float circleradius = 1f;
        for (int i = 0; i < 8; i++)
        {
            float angle = i * Mathf.PI * 2f / 8;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * circleradius, Mathf.Sin(angle) * circleradius, 0 );
            //GameObject go = Instantiate(bolt, newPos, Quaternion.identity);

            fire(newPos.x, newPos.y, firepoint);
        }
    }

    void xattack(int firepoint)
    {
        for (int i = 0; i < 4; i++)
        {
            fire(i * radius/2, i * radius/2, firepoint);
            fire(-i * radius/2, -i * radius/2, firepoint);
            fire(-i * radius/2, i * radius/2, firepoint);
            fire(i * radius/2, -i * radius/2, firepoint);
        }
    }

    void random(int firepoint)
    {
        if(firepoint==1)
        {
            Instantiate(randombolt, new Vector3(enemyfirepoint1.transform.position.x, enemyfirepoint1.transform.position.y, 0), Quaternion.identity);

        }

        else if (firepoint ==2)
        {
            Instantiate(randombolt, new Vector3(enemyfirepoint2.transform.position.x, enemyfirepoint2.transform.position.y, 0), Quaternion.identity);
        }
    }
    void attackchoice(int firepoint)
    {
        whichattack = Random.Range(0, 3);
        
        switch(whichattack)
        {
            case 0: vattack(firepoint);
                break;
            case 1: oattack(firepoint);
                break;
            case 2: xattack(firepoint);
                break;
            default: vattack(firepoint);
                break;
        }
    }

    void homingcircleattack()
    {
        Instantiate(center,enemyfirepoint3.transform.position, Quaternion.identity);
    }

    void spawnsnakes()
    {

        Instantiate(snakeprefab, new Vector3(transform.position.x - 7, transform.position.y + 2, 0), Quaternion.identity);
        Instantiate(snakeprefab, new Vector3(transform.position.x - 5, transform.position.y + 2, 0), Quaternion.identity);
        Instantiate(snakeprefab, new Vector3(transform.position.x +4, transform.position.y + 2, 0), Quaternion.identity);
        Instantiate(snakeprefab, new Vector3(transform.position.x + 6, transform.position.y + 2, 0), Quaternion.identity);
        Instantiate(snakeprefab, new Vector3(transform.position.x -2, transform.position.y -5, 0), Quaternion.identity);
        Instantiate(snakeprefab, new Vector3(transform.position.x +1, transform.position.y - 5, 0), Quaternion.identity);
        Instantiate(snakeprefab, new Vector3(transform.position.x-.5f, transform.position.y - 5, 0), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        secondaryattacktimer += Time.deltaTime;

        if (timer >= .5f)
        {
            basicattack();
            random(1);
            random(2);
            timer = 0;
        }

        if(GetComponent<BossEnemy>().health<maxhealth/2 && spawned==false)
        {
            spawnsnakes();
            spawned = true;
        }
        if(secondaryattacktimer>=1.5f)
        {
            int randomfirepoint = Random.Range(1, 3);
            Debug.Log(randomfirepoint);
            attackchoice(randomfirepoint);
            secondaryattacktimer = 0;
        }
        
        if(GameObject.FindGameObjectWithTag("enemy3attack")==null)
        {
            homingcircleattack();
        }


    }
}
