using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace VD
{
    public class EnemySpawner : MonoBehaviour
    {

        [SerializeField] private Transform _spawnPoint;
        private const float  BaseScale = 3.0f;

        private EnemyFactory _enemyFactory;
        [Inject]
        private void Construct(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public void StartWork()
        {
            Spawn();
        }

        public Enemy Spawn()
        {
            Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.transform.SetParent(_spawnPoint);
            enemy.transform.localScale = new Vector3(BaseScale, BaseScale, BaseScale);
            enemy.transform.position = _spawnPoint.position;

            return enemy;
        }

    }
}
