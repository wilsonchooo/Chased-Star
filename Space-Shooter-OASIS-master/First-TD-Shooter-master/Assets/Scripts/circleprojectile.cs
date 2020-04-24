using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleprojectile : MonoBehaviour
{
    // Start is called before the first frame update
    private float RotateSpeed = 2.5f;
    private float Radius = 1f;

    private float timer;
    public GameObject center;

    private Vector2 centre;
    private float angle;
    public float speed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("enemy3attack")!=null)
        {
            centre = GameObject.FindGameObjectWithTag("enemy3attack").transform.position;
            angle += RotateSpeed * Time.deltaTime;
            var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
            transform.position = centre + offset;
        }


        if (transform.position.y <= -10 || transform.position.x <= -10 || transform.position.x >= 10)
            Destroy(this.gameObject);
    }


}
