using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private BaseWeapon weapon;

    public Transform firePoint;

    private int _currentAmmo = 0;
    private float _currentCooldown;

    // Start is called before the first frame update
    void Start()
    {
        _currentAmmo = weapon.AmmoCapacity;
        _currentCooldown = weapon.FireRate;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        Vector3 pos = firePoint.position;

        if (_currentCooldown > 0)
        {
            _currentCooldown -= Time.deltaTime;

        }
        else if (_currentCooldown <= 0)
        {
            GameObject newBullet = Instantiate(weapon.BulletPrefab, pos, firePoint.rotation);
            //newBullet.owner = this.gameObject.GetComponent<>();
            _currentCooldown = weapon.FireRate;
        }
    }
}
