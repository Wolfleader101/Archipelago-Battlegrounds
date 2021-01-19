// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Runtime.CompilerServices;
// using DefaultNamespace;
// using UnityEngine;
// using UnityEngine.Serialization;
//
// public class BaseWeapon2 : MonoBehaviour
// {
//     public Transform firePoint;
//     public BaseBullet bulletPrefab;
//     public float bulletYOffset;
//
//     public float shootCooldown = 3f;
//     private float _currentCooldown;
//     public int maxAmmo = 10;
//     public int currentAmmo = 0;
//
//     public BaseReload reloadPrefab;
//     public float reloadTime = 1.2f;
//
//     // public Transform enemy;
//     private bool _canShoot;
//     private bool _canReload = false;
//
//     public Canvas canvas;
//
//
//     protected virtual void Start()
//     {
//         _currentCooldown = shootCooldown;
//         _canShoot = true;
//         currentAmmo = maxAmmo;
//     }
//
//     // Update is called once per frame
//     protected virtual void Update()
//     {
//         canvas.transform.rotation = Quaternion.identity;
//         if (Input.GetButtonDown("Fire1") && _canShoot)
//         {
//             currentAmmo--;
//             _canReload = true;
//             if (currentAmmo >= 0)
//             {
//                 Shoot();
//             }
//         }
//
//         if (currentAmmo == maxAmmo) _canReload = false;
//
//         if (Input.GetKeyDown("r") && _canReload == true)
//         {
//             StartCoroutine(Reload(reloadTime));
//         }
//     }
//
//     IEnumerator Reload(float time)
//     {
//         _canReload = false;
//         _canShoot = false;
//         BaseReload newReload = Instantiate(reloadPrefab, transform.position, transform.rotation);
//         newReload.parent = canvas;
//         newReload.timeAmount = reloadTime;
//
//         yield return new WaitForSeconds(time);
//         currentAmmo = maxAmmo;
//         _canShoot = true;
//         _canReload = true;
//     }
//
//     public virtual void Shoot()
//     {
//         // if (currentAmmo == 0 && canReload == true)
//         // {
//         //     StartCoroutine( Reload(reloadTime) );
//         // }
//         Vector3 pos = firePoint.position;
//         pos.y += bulletYOffset;
//
//
//         if (_currentCooldown > 0)
//         {
//             _currentCooldown -= Time.deltaTime;
//
//         }
//         else if (_currentCooldown <= 0)
//         {
//             BaseBullet newBullet = Instantiate(bulletPrefab, pos, firePoint.rotation);
//             newBullet.owner = this.gameObject.GetComponent<BaseEntity>();
//             _currentCooldown = shootCooldown;
//         }
//     }
// }