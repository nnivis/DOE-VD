using UnityEngine;
using Zenject;

namespace VD
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        private int _health;
        private float _speed;

        public void ApplyDamage(int damage)
        {
            Debug.Log("Enemy Damage");
        }

        public void ApplyHealing(int amount)
        {
             Debug.Log("Enemy Health");
        }

        public virtual void Initialize(int helath, float speed)
        {
            _health = helath;
            _speed = speed;

            Debug.Log($"��: {_health}, ��������: {_speed}");
        }
        public void MoveTo(Vector3 position) => transform.position = position;
    }
}