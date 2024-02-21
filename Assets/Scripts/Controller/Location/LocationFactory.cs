using UnityEngine;

namespace VD
{
    [CreateAssetMenu(fileName = "LocationFactory", menuName = "Factory/LocationFactory", order = 1)]
    public class LocationFactory : ScriptableObject
    {
        
       [SerializeField] private LocationConfig _locationConfig;
       private DiceFactory _diceFactory;
       private RollDiceConfig _rollDiceConfig;
       private EnemyFactory _enemyFactory;




    }
}
