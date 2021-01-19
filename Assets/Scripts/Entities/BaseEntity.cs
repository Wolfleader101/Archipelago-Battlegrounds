using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 100;
    public int currentHealth;
    
    [Header("Objects")]
    public BaseWeapon weapon;
    public Transform enemy;
    
    [Header("Targeting")]
    public int targetDistance = 10;
    public int outOfRange = 20;
    //public float speed = 10;

    private Vector2 _currentVelocity;
    // public GameObject damageEffect;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        weapon = this.GetComponent<BaseWeapon>();
        // weapon.enemy = enemy;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void FixedUpdate()
    {
        if(enemy == null) return;
        float dist = Vector2.Distance(transform.position, enemy.position);
        if (dist <= targetDistance && dist <= outOfRange)
        {
            Vector3 dir = (enemy.position - transform.position).normalized;

            if (dir.x > 0) // blue
            {
                transform.localScale = new Vector3(1, 1,1 );
            } else if (dir.x < 0) //red
            {
                transform.localScale = new Vector3(-1, 1,1 );
            }
            
            
            transform.up = (enemy.position - transform.position).normalized;
            weapon.Shoot();

            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();

            // if (currentHealth > 50)
            // {
            //     currentVelocity.x = dir.x * speed;
            //     currentVelocity.y += Physics2D.gravity.y;
            //     rb.velocity = currentVelocity;
            //
            // }
            // else
            // {
            //     currentVelocity.x = dir.x * -speed;
            //     currentVelocity.y += Physics2D.gravity.y;
            //     rb.velocity = currentVelocity;
            // }
            
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