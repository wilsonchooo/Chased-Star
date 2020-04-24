using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randombolt : MonoBehaviour
{

    public float speed;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(randomDirection);
        direction = Random.insideUnitCircle.normalized;


        transform.Rotate(direction);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += transform.forward*Time.deltaTime;
        GetComponent<Rigidbody2D>().AddForce(direction * speed);
    }
}
