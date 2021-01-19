using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class BaseWeapon : ScriptableObject
{
    [SerializeField] private int ammoCapacity = 10;
    public int AmmoCapacity => ammoCapacity;
    
    [SerializeField] private float fireRate = 1;
    public float FireRate => fireRate;
    
    [SerializeField] private GameObject bulletPrefab;
    public GameObject BulletPrefab => bulletPrefab;
    
}
