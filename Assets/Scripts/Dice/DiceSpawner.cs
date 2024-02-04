using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VD
{
    public class DiceSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private DiceFactory _diceFactory;
        [SerializeField] private int _minSpawnCount;
        [SerializeField] private int _maxSpawnCount;
        private AbilityMediator _abilityMediator;
        private Coroutine _spawn;
        private int spawnedCount = 0;
        private const float BaseScale = 0.3f;

        public void StartWork(AbilityMediator abilityMediator)
        {
            _abilityMediator = abilityMediator;

            StopWork();
            _spawn = StartCoroutine(Spawn());
        }

        public void StopWork()
        {
            if (_spawn != null)
                StopCoroutine(_spawn);
        }

        private IEnumerator Spawn()
        {
            while (spawnedCount < _maxSpawnCount)
            {
                int spawnCount = UnityEngine.Random.Range(_minSpawnCount, _maxSpawnCount + 1);

                for (int i = 0; i < spawnCount && spawnedCount < _maxSpawnCount; i++)
                {
                    Transform selectedSpawnPoint = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)];
                    Dice dice = _diceFactory.Get((DiceType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(DiceType)).Length));
                    dice.SetAbilityMediator(_abilityMediator);
                    dice.transform.localScale = new Vector3(BaseScale, BaseScale, BaseScale);
                    dice.transform.SetParent(selectedSpawnPoint, false);
                    dice.MoveTo(selectedSpawnPoint.position);

                    spawnedCount++;
                }
                yield return new WaitForSeconds(_spawnCooldown);
            }
        }
    }
}
