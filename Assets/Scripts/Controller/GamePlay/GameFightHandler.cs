using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace VD
{
    public class GameFightHandler : MonoBehaviour
    {
        [SerializeField] private MainSceneMode _mainSceneMode;
        [SerializeField] private DiceSpawner _diceSpawner;
        [SerializeField] private CharacterSpawner _characterSpawner;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private Timer _timer;
        private AbilityMediator _abilityMediator;
        private GamePlayMediator _gamePlayMediator;
        private Character _character;
        private Enemy _enemy;
        private List<Dice> _activeDice = new List<Dice>();

        [Inject]
        private void Construct(AbilityMediator abilityMediator, GamePlayMediator gamePlayMediator)
        {
            _abilityMediator = abilityMediator;
            _gamePlayMediator = gamePlayMediator;

            _diceSpawner.Initialize(_abilityMediator);
        }

        private void OnEnable()
        {
            _gamePlayMediator.OnGameOver += GameFightOver;
        }
        private void OnDisable()
        {
            _activeDice.ForEach(dice => dice.OnDestroyed -= DiceDestroyed);
            _gamePlayMediator.OnGameOver -= GameFightOver;
        }
        private void SpawnComponents()
        {
            _character = _characterSpawner.SpawnCharacter();
            _enemy = _enemySpawner.SpawnEnemy();
            _diceSpawner.SpawnDice();
            _diceSpawner.SpawnFinished += AddSpawnedDiceToActiveDice;
        }
        private void DiceDestroyed()
        {
            _activeDice.RemoveAt(0);
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


        }

        private void ChangeScene(GameFightEndReason reason)
        {
            switch (reason)
            {
                case GameFightEndReason.PlayerDeath:
                    _mainSceneMode.GotoEndGame();
                    break;
                case GameFightEndReason.EnemyDeath:
                    _mainSceneMode.GotoWinGame();
                    break;
                case GameFightEndReason.TimeUp:
                    _mainSceneMode.GotoEndGame();
                    break;
                default:
                    throw new ArgumentException(nameof(reason));
            }
        }

        private void ClearLevel()
        {
            Destroy(_character);
            Destroy(_enemy);
            _activeDice.Clear();
            _diceSpawner.RemoveAllChildren();
        }
        public void StartFight()
        {
            ClearLevel();

            SpawnComponents();
            _abilityMediator.SetComponent(_character, _enemy);
            _timer.StartTimer();
        }
    }
}
