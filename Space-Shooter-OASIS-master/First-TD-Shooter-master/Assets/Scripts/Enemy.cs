using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] GameObject UIinfo;
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 60;

    [Header("Shooting")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBeforeEachShot = .5f;
    [SerializeField] float maxTimeBeforeEachShot = 3f;
    [SerializeField] GameObject EnemyBulletPrefab;
    [SerializeField] float projectileSpeed = 5f;

    [Header("Audio")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathSFXVolume = 0.5f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;
    [SerializeField] GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBeforeEachShot, maxTimeBeforeEachShot);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot(); 
    }

    private void CountDownAndShoot()
    {
        //shotCounter - the time it takes for one frame to register
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBeforeEachShot, maxTimeBeforeEachShot);
        }

    }

    private void Fire()
    {
        //creates laser object at player position without altering rotation
        GameObject laser =
            Instantiate(EnemyBulletPrefab, transform.position, Quaternion.identity)
            as GameObject;
        //call physics of object and adjust it's motion by adjusting the velocity
        //- projectile speed to send it down
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }


    //use other to refer to the gameobject that hit instead of the collision or collider that hit
    //other is the parameter
    private void OnTriggerEnter2D(Collider2D other)
    {
        //local variable damageDealer  
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
        Instantiate(explosion,transform.position,Quaternion.identity);
        Destroy(gameObject);
        FindObjectOfType<GamePlayUI>().AddToScore(scoreValue);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
        //laserSound.Play();
    }
}
