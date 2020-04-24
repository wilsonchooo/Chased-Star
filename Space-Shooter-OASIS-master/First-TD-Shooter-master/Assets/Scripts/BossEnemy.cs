using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    [SerializeField] public float health = 100;
    [SerializeField] GameObject explosion;
    private GameObject explode;
    // Start is called before the first frame update
    void Start()
    {
        explode = explosion;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //use other to refer to the gameobject that hit instead of the collision or collider that hit
    //other is the parameter
    private void OnTriggerEnter2D(Collider2D other)
    {

            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
            //it's easy to write out code in one method and then use extract method (used for ProcessHit)
            ProcessHit(damageDealer);

    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {

            Die();
        }
    }

    private void Die()
    {
        Instantiate(explode, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //FindObjectOfType<GamePlayUI>().AddToScore(scoreValue);
        //AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
        //laserSound.Play();
        FindObjectOfType<Level>().LoadVictory();
    }
}
