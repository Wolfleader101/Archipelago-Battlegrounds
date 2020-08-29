using UnityEngine;

namespace DefaultNamespace
{
    public class BaseBullet : MonoBehaviour
    {
        public float speed = 20f;

        public Rigidbody2D rb;
        public int damage = 30;

        // Start is called before the first frame update
        void Start()
        {
            rb.velocity = transform.up * speed;
        }

        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            BaseEntity enemy = hitInfo.GetComponent<BaseEntity>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);

            }
            Destroy(gameObject);
        
        }
    }
}