using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Fire")]
    [SerializeField] float health = 100;
    [SerializeField] float ShotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject ProjectilePrefab;
    [SerializeField] float ProjectileSpeed = 3f;
    [Header("Visual Effect")]
    [SerializeField] GameObject dyingVfx;
    


    [Header("Sound Effect")]
    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.7f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)]float shootSoundVolume = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        CountDownAndShot();

       
    }
    private void CountDownAndShot()
    {
        ShotCounter -= Time.deltaTime;
        if(ShotCounter<= 0f)
        {
            Fire();
            ShotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject EnemyProjectile = Instantiate(ProjectilePrefab,transform.position,Quaternion.identity) as GameObject;
        EnemyProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -ProjectileSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealerl damageDealer = other.gameObject.GetComponent<DamageDealerl>();
        if (!damageDealer){ return; }
        ProcessHit(damageDealer);

    }

    private void ProcessHit(DamageDealerl damageDealer)
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
        Destroy(gameObject);
        GameObject Explosion = Instantiate(dyingVfx, transform.position, Quaternion.identity);
        Destroy(Explosion, 0.2f);
        AudioSource.PlayClipAtPoint(deathSFX,Camera.main.transform.position,deathSoundVolume);
    }
}
