﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zucchiniprojectile : MonoBehaviour
{
    [SerializeField] float speed = 3.5f;
    [SerializeField] float damage= 100f;
    [SerializeField] GameObject particleEffect;
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

  

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D othercollider)
    {
        var health = othercollider.GetComponent<Health>();
        var attacker = othercollider.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);

        }
        
    }
}
