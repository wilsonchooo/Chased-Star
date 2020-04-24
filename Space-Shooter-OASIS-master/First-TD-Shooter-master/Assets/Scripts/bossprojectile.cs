using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossprojectile : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer;
    public GameObject player;
    public float speed;
    private Vector3 playerloc;
    private Vector3 movedirection;
    void Start()
    {
        playerloc = player.transform.position;
        //Physics2D.IgnoreCollision(this.GetComponent<BoxCollider2D>(), player.GetComponent<BoxCollider2D>());

        GameObject play = GameObject.Find("Player");
        if(play!=null)
        movedirection = (play.transform.position - transform.position).normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(movedirection.x, movedirection.y);
        timer = 0;

        if (transform.position.y <= -10 || transform.position.x <= -10 || transform.position.x >= 10)
            Destroy(this.gameObject);
    }


}
