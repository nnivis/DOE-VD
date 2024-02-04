using UnityEngine;
using Zenject;

namespace VD
{
    public class GameFightHandler : MonoBehaviour
    {
        [SerializeField] private DiceSpawner _diceSpawner;
        [SerializeField] private CharacterSpawner _characterSpawner;
        [SerializeField] private EnemySpawner _enemySpawner;
        private AbilityMediator _abilityMediator;
        private Character _character;
        private Enemy _enemy;

        [Inject]
        private void Construct(AbilityMediator abilityMediator)
        {
            _abilityMediator = abilityMediator;
        }

        public void StartGame()
        {
            Spawn();
            _abilityMediator.SetComponent(_character, _enemy);
        }

        private void Spawn()
        {
            _diceSpawner.StartWork(_abilityMediator);
            _character = _characterSpawner.SpawnCharacter();
            _enemy = _enemySpawner.Spawn();
        }
    }
}
