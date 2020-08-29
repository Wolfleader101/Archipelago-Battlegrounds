using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseWeapon : MonoBehaviour
{
    public Transform firePoint;
    public BaseBullet bulletPrefab;
    public float BulletYOffset;
    
    public int maxAmmo = 10;
    public int currentAmmo = 0;

    public BaseReload reloadPrefab;
    public float reloadTime = 1.2f;

    private bool canShoot;
    private bool canReload = false;
    
    public Canvas canvas;

    private void Start()
    {
        canShoot = true;
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        canvas.transform.rotation = Quaternion.identity;
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            currentAmmo--;
            canReload = true;
            if (currentAmmo >= 0)
            {
                Shoot();
            }
        }
        
        if(currentAmmo == maxAmmo) canReload = false;

        if (Input.GetKeyDown ("r") && canReload == true) {
            StartCoroutine( Reload(reloadTime) );
        }
    } 

    IEnumerator Reload(float time) {
        canReload = false;
        canShoot = false;
        BaseReload newReload = Instantiate(reloadPrefab, transform.position, transform.rotation);
        newReload.parent = canvas;
        newReload.timeAmount = reloadTime;
        
        yield return new WaitForSeconds(time);
        currentAmmo = maxAmmo;
        canShoot = true;
        canReload = true;
    }
    void Shoot()
    {
        Vector3 pos = firePoint.position;
        pos.y += BulletYOffset;
        BaseBullet newBullet = Instantiate(bulletPrefab, pos, firePoint.rotation);
    }
}
