using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossminion : MonoBehaviour
{
    private float timer;
    public GameObject lazerparent;
    public GameObject firepoint;
    private Vector3 location;

    // Start is called before the first frame update
    void Start()
    {
        location = gameObject.transform.Find("lazerparent").transform.position;

}

    // Update is called once per frame
    void Update()
    {

        if (gameObject.transform.Find("lazerparent") == null && gameObject.transform.Find("lazerparent(Clone)") == null)
        {
            timer += Time.deltaTime;
            if (timer >= 3)
            {
                GameObject lazer = Instantiate(lazerparent, location, Quaternion.identity);
                lazer.transform.parent = gameObject.transform;
                timer = 0;
            }

        }

    }
}
