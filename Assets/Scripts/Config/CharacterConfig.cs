using UnityEngine;

namespace VD
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Config/CharacterConfig", order = 1)]
    public class CharacterConfig : ScriptableObject
    {

        [SerializeField, Range(0,200)] private int _maxHealth;
        [SerializeField, Range(0,100)] private int _baseDamage;

        public int MaxHealth  => _maxHealth;
        public int BaseDamage => _baseDamage;

    }
}
