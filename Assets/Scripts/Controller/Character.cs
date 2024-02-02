using UnityEngine;
using Zenject;

namespace VD
{
    public class Character : MonoBehaviour
    {

        private int _maxHealth;
        private int _health;
        private int _damage;

        public void Initialization(CharacterConfig characterConfig)
        {
            _health = _maxHealth = characterConfig.MaxHealth;
            _damage = characterConfig.BaseDamage;
            Debug.Log($"� ���� {_health} ��");
        }

        public void TakeDamage(int damage)
        {
            Debug.Log($"������� {damage} �����");
        }

        public void ChangeScale()
        {
            transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        }
    }
}
