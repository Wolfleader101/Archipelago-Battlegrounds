using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;

    public float MaxHealth => maxHealth;

    private float _currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public virtual void TakeDamage(float damage)
    {
        //GameObject effect = Instantiate(damageEffect, transform.position, quaternion.identity);

        _currentHealth -= damage;

        if (_currentHealth <= 0)
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