using System;
using UnityEngine;
using Zenject;

namespace VD
{
    public class Character : MonoBehaviour, IDamageable
    {
        public Action onDead;
        public Action onDamage;
        private HealthComponent _healthComponent;
        [SerializeField] private ViewComponent _viewComponent;

        public void Initialization(CharacterConfig config)
        {
            _healthComponent = new HealthComponent(config.MaxHealth);
        }
        public int CurrentHealth => _healthComponent.currentHealth;
        public int MaxHealth => _healthComponent.maxHealth;
        public void ApplyDamage(int damage)
        {
            _healthComponent.ReduceHealth(damage);
            _viewComponent.UpdateHealth(CurrentHealth, MaxHealth);
            onDamage?.Invoke();

            if (_healthComponent.isDead) Death();
        }

        private void Death()
        {
            onDead?.Invoke();
            Destroy(gameObject);
        }

        public void ApplyHealing(int amount)
        {
            Debug.Log("Character Health");
        }
    }
}
