using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossminionlazer : MonoBehaviour
{
    float timer;
    float timer2;
    float timebeforefire;
    public float lazerexpansiontime;
    public float lazerclosetime;

    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0, transform.localScale.y, 0);

    }

    // Update is called once per frame
    void Update()
    {
        timebeforefire += Time.deltaTime;
        if(timebeforefire>2)
        {
            timer += Time.deltaTime;
            if (timer < 1.4f)
            {
                transform.localScale += new Vector3(Time.deltaTime* lazerexpansiontime, 0, 0);
                AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            }
            else
            {
                timer2 += Time.deltaTime;
                if (timer2 >= 1)
                {
                    if (transform.localScale.x >= 0)
                        transform.localScale += new Vector3(-Time.deltaTime* lazerclosetime, 0, 0);
                    //AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
                }

            }
        }

       

        if((transform.localScale.x < 0))
        {
            //Destroy(gameObject);
            timebeforefire = 0;
            timer = 0;
            timer2 = 0;
            transform.localScale = new Vector3(0, transform.localScale.y, 0);
        }



    }

    private void ProcessHit(DamageDealerLazer damageDealer)
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //local variable damageDealer  
            DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
            //it's easy to write out code in one method and then use extract method (used for ProcessHit)
            //ProcessHit(damageDealer);
        }
    }

    

}
