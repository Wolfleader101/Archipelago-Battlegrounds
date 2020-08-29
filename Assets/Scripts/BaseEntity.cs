﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    
    public Transform enemy;
    public int targetDistance = 10;
    public int outOfRange = 20;
    public float speed = 10;
    
    // public GameObject damageEffect;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float dist = Vector2.Distance(transform.position, enemy.position);
        if (dist <= targetDistance && dist <= outOfRange)
        {
           // Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
           // rb.AddForce(enemy.position * speed);
        }
    }

    public virtual void TakeDamage(int damage)
    {
        //GameObject effect = Instantiate(damageEffect, transform.position, quaternion.identity);
        
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    protected virtual void Die()
    {
        Destroy(gameObject);
        //Instantiate(deatheffectSprite, transform.position, quaternion.identity);
    }
}