using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randommovement : MonoBehaviour
{
    Vector2 direction;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        direction = Random.insideUnitCircle.normalized;
        //direction = new Vector2(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime*speed);

        if (transform.position.y <= -10 || transform.position.x <= -10 || transform.position.x >= 10)
            Destroy(this.gameObject);
    }


    
}
