using UnityEngine;

namespace VD
{
    public class HealthComponent 
    {
        [SerializeField] int _currentHealth;
        [SerializeField] int _maxHealth;
        public HealthComponent(int health)
        {
            _maxHealth = health;
            _currentHealth = health;
        }
        public int maxHealth => _maxHealth;
        public int currentHealth => _currentHealth;
        public bool isDead => _currentHealth <= 0;
        public float percent => _currentHealth / _maxHealth;

        public void ReduceHealth(int damage)
        {
            _currentHealth = Mathf.Max(_currentHealth - damage, 0);
        }
    }
}
