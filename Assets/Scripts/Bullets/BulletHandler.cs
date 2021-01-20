using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable 0649
public class BulletHandler : MonoBehaviour
{
    [SerializeField] private BaseBullet bullet;
    public Rigidbody2D rb;
    
    //public BaseEntity owner;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bullet.Speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //if (this.GetComponent<BaseBlue>() && hitInfo.GetComponent<BaseBlue>()) return;
        //if (this.GetComponent<BaseRed>() && hitInfo.GetComponent<BaseRed>()) return;
        if (hitInfo.GetComponent<BulletHandler>()) return;
        //BaseEntity enemy = hitInfo.GetComponent<BaseEntity>();
        //if (enemy == owner) return;
        
        //if (enemy != null)
        //{
        //    enemy.TakeDamage(damage);

        // }
        Destroy(this.gameObject);
        
    }
}
