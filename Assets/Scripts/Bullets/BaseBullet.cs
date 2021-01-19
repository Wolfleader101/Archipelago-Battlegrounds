// using UnityEngine;
//
//
// public class BaseBullet : MonoBehaviour
// {
//         public float speed = 20f;
//
//         public Rigidbody2D rb;
//         public int damage = 30;
//
//         public BaseEntity owner;
//         // Start is called before the first frame update
//         void Start()
//         {
//             rb.velocity = transform.up * speed;
//         }
//
//     private void OnTriggerEnter2D(Collider2D hitInfo)
//     {
//         //if (this.GetComponent<BaseBlue>() && hitInfo.GetComponent<BaseBlue>()) return;
//         //if (this.GetComponent<BaseRed>() && hitInfo.GetComponent<BaseRed>()) return;
//         if (hitInfo.GetComponent<BaseBullet>()) return;
//         BaseEntity enemy = hitInfo.GetComponent<BaseEntity>();
//         if (enemy == owner) return;
//         
//         if (enemy != null)
//         {
//             enemy.TakeDamage(damage);
//
//         }
//         Destroy(this.gameObject);
//         
//     }
// }