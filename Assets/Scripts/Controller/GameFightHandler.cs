using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace VD
{
    public class GameFightHandler : MonoBehaviour
    {
        [SerializeField] private DiceSpawner _diceSpawner;
        [SerializeField] private CharacterSpawner _characterSpawner;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private Timer _timer;
        private AbilityMediator _abilityMediator;
        private GamePlayMediator _gamePlayMediator;
        private GameFightEnder _gameFightEnder;
        private Character _character;
        private Enemy _enemy;
        private List<Dice> _activeDice = new List<Dice>();

        [Inject]
        private void Construct(AbilityMediator abilityMediator, GamePlayMediator gamePlayMediator)
        {
            _abilityMediator = abilityMediator;
            _gamePlayMediator = gamePlayMediator;
            _gamePlayMediator.OnGameOver += GameFightOver;
            _diceSpawner.Initialize(_abilityMediator);
        }

        public void StartGame()
        {
            SpawnComponents();
            _abilityMediator.SetComponent(_character, _enemy);
            _timer.StartTimer();
        }


        private void OnDisable()
        {
            _activeDice.ForEach(dice => dice.OnDestroyed -= DiceDestroyed);
        }

        private void SpawnComponents()
        {
            _diceSpawner.SpawnDice();
            _character = _characterSpawner.SpawnCharacter();
            _enemy = _enemySpawner.SpawnEnemy();
            _diceSpawner.SpawnFinished += AddSpawnedDiceToActiveDice;
        }

        private void DiceDestroyed()
        {
            _activeDice.RemoveAt(0);

            Debug.Log(_activeDice.Count);

            if (_activeDice.Count == 0)
            {
                _activeDice.Clear();
                _diceSpawner.SpawnDice();
                _diceSpawner.SpawnFinished += AddSpawnedDiceToActiveDice;
            }

        }
        private void AddSpawnedDiceToActiveDice()
        {
            _activeDice.AddRange(_diceSpawner.SpawnedDice);
            _activeDice.ForEach(dice => dice.OnDestroyed += DiceDestroyed);
            _diceSpawner.SpawnFinished -= AddSpawnedDiceToActiveDice;
        }
        private void GameFightOver(GameFightEndReason reason)
        {
            Debug.Log(reason);
        }
    }
}
