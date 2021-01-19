using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private BaseWeapon weapon;

    public Transform firePoint;

    private int _currentAmmo;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentAmmo = weapon.AmmoCapacity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
