using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 0649
public class EntityTargeting : MonoBehaviour
{
    [SerializeField] private float targetDistance = 10f;
    
    public float TargetDistance => targetDistance;


    [SerializeField] private float outOfRange = 20f;
    
    public float OutOfRange => outOfRange;
    

    [SerializeField] private Transform target;

    public Transform Target => target;

    [SerializeField] private WeaponHandler weapon;

    public WeaponHandler Weapon => weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon = this.GetComponentInChildren<WeaponHandler>();
    }

    public void FixedUpdate()
    {
        if(target == null) return;
        float dist = Vector2.Distance(transform.position, target.position);
        if (dist <= targetDistance && dist <= outOfRange)
        {
            Vector3 dir = (target.position - transform.position).normalized;

            if (dir.x > 0) // to the right
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            } else if (dir.x < 0) // to the left
            {
                transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
            
            weapon.Shoot();

        }
    }
}
