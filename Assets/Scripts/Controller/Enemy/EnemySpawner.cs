using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace VD
{
    public class EnemySpawner : MonoBehaviour
    {

        [SerializeField] private Transform _spawnPoint;
        private const float BaseScale = 3.0f;
        private GamePlayMediator _gamePlayMediator;
        private EnemyFactory _enemyFactory;
        [Inject]
        private void Construct(EnemyFactory enemyFactory, GamePlayMediator gamePlayMediator)
        {
            _enemyFactory = enemyFactory;
            _gamePlayMediator = gamePlayMediator;
        }

        public Enemy SpawnEnemy()
        {
            Enemy enemy = _enemyFactory.Get();
            enemy.onDead += (GameOverType) => _gamePlayMediator.NotifyGameOver(enemy.GameOverType);
            enemy.transform.SetParent(_spawnPoint);
            enemy.transform.localScale = new Vector3(BaseScale, BaseScale, BaseScale);
            enemy.transform.position = _spawnPoint.position;

            return enemy;
        }

    }
}
