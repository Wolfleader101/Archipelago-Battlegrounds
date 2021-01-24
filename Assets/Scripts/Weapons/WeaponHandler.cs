using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
#pragma warning disable 0649
public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private BaseWeapon weapon;

    public Transform firePoint;

    public GameObject point;
    private GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;

    public EntityTargeting targeting;
    private Vector2 direction;
    
    private int _currentAmmo = 0;
    private float _currentCooldown;

    // Start is called before the first frame update
    void Start()
    {
        _currentAmmo = weapon.AmmoCapacity;
        _currentCooldown = weapon.FireRate;

        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, firePoint.position, quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
      //  Shoot();
      Vector2 gunPosition = transform.position;
      direction = (Vector2) targeting.Target.position - gunPosition;
      for (int i = 0; i < numberOfPoints; i++)
      {
          points[i].transform.position = PointPosition(i * spaceBetweenPoints);
      }
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

    Vector2 PointPosition(float time)
    {
        Vector2 position = (Vector2) firePoint.position +
                           (direction.normalized * 20 * time) +
                           0.5f * Physics2D.gravity * (time * time);
        return position;
    }
}
