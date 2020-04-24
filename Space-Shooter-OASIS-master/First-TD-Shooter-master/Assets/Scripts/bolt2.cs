using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolt2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    Vector2 direction;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - .02f, transform.position.z);

        


        if (transform.position.y <= -10 || transform.position.x <= -10 || transform.position.x >= 10)
            Destroy(this.gameObject);
    }


}
