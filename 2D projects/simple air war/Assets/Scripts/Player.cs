using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //config parameters
    [Header("Player ")]
    [SerializeField] float moveSpeed= 10f;
    [SerializeField] float padding = 0.5f;
    [SerializeField] int health = 200;
    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 20f;
    [SerializeField] float projectileFiringperiod = 0.1f;
    [SerializeField] GameObject dyingVfx;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.7f;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;
    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        
            }
   
    // Update is called once per frame
    void Update()
    {

        Move();
        Fire();
    }
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {

          firingCoroutine =  StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }
    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringperiod);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);


        }

    }

    

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x+ padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x-padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y+ padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y-padding;
    }

   
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal")* Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newYPos =Mathf.Clamp(transform.position.y + deltaY,yMin,yMax);
        var newXPos = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);
        transform.position = new Vector2(newXPos, newYPos);
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealerl getDamage = other.gameObject.GetComponent<DamageDealerl>();
        if (!getDamage)
        {
            return;
        }
        ProcessHit(getDamage);
    }
    private void ProcessHit(DamageDealerl playerdamage)
    {
        health -= playerdamage.GetDamage();
        playerdamage.Hit();
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
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }

}
