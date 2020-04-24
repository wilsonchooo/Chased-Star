using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circlecenter : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public GameObject projectileprefab;
    private float timer;
    private float timer2;
    private int count;
    private GameObject instantiated;
    private Vector3 movedirection;
    public GameObject player;
    public float speed;
    private Rigidbody2D rb;
    void Start()
    {
        timer = 0;
        rb = GetComponent<Rigidbody2D>();
        GameObject play = GameObject.FindGameObjectWithTag("Player");
        if(play!=null)
        movedirection = (play.transform.position - transform.position).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= .10f && count <= 24)
        {
            instantiated = Instantiate(projectileprefab, transform.position, Quaternion.identity);
            instantiated.transform.parent = gameObject.transform;
            timer = 0;
            count++;
        }
        if (count >= 24)
        {
            timer2 += Time.deltaTime;
            if (timer2 >= 3)
            {
                GameObject play = GameObject.Find("Player");
                if(play!=null)
                {
                    movedirection = (play.transform.position - transform.position).normalized * speed;
                    rb.velocity = new Vector2(movedirection.x, movedirection.y);
                }

                timer2 = 0;
                count = 0;
            }
        }

        //transform.position = new Vector3(transform.position.x, transform.position.y-.5f, transform.position.z);
        if (transform.position.y <= -10 || transform.position.x <= -10 || transform.position.x >= 10)
            Destroy(this.gameObject);
    }
}
