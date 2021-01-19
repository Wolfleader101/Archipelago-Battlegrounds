using UnityEngine;


[CreateAssetMenu(menuName = "Bullet")]
public class BaseBullet : ScriptableObject
{
        [SerializeField] private float speed = 20f;
        public float Speed => speed;
        
        [SerializeField]
        private int damage =  15;
        public int Damage => damage;
}