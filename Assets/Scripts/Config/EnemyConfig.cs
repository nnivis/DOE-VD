using UnityEngine;

namespace VD
{
    [CreateAssetMenu(fileName ="EnemyConfig", menuName ="Config/EnemyConfig", order = 2)]
    public class EnemyConfig : ScriptableObject
    {
       [SerializeField] private int _health;
       [SerializeField] private int _damage;
    }
}
