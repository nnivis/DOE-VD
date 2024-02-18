using System;
using UnityEngine;

namespace VD
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        public Action<GameFightEndReason> onDead;
        public GameFightEndReason GameOverType => _gameOverType;
        public Action onDamage;
        private HealthComponent _healthComponent;
        private GameFightEndReason _gameOverType;
        [SerializeField] private ViewComponent _viewComponent;
        public virtual void Initialize(EnemyConfig config)
        {
            _healthComponent = new HealthComponent(config.MaxHealth);
            _gameOverType = GameFightEndReason.EnemyDeath;
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
            onDead?.Invoke(_gameOverType);

        }
        public void ApplyHealing(int amount)
        {
            Debug.Log("Enemy Health");
        }
    }
}