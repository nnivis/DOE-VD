using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace VD
{
    public class DiceSpawner : MonoBehaviour
    {
        public List<Dice> SpawnedDice => _spawnedDices;
        public event Action SpawnFinished;
        [SerializeField] private float _spawnCooldown = 0.5f;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private DiceFactory _diceFactory;
        [SerializeField] private int _minSpawnCount;
        [SerializeField] private int _maxSpawnCount;
        private ILocationProvaider _locationProvaider;
        private List<Dice> _spawnedDices = new List<Dice>();
        private AbilityMediator _abilityMediator;
        private Coroutine _spawn;
        private int _spawnedCount;
        private const float BaseScale = 0.3f;

        public void Initialize(AbilityMediator abilityMediator)
        {
            _abilityMediator = abilityMediator;
        }

        [Inject]
        private void Construct(ILocationProvaider locationProvaider)
        {
            _locationProvaider = locationProvaider;
        }
        private IEnumerator Spawn()
        {
            while (_spawnedCount < _maxSpawnCount)
            {
                int spawnCount = UnityEngine.Random.Range(_minSpawnCount, _maxSpawnCount + 1);
                for (int i = 0; i < spawnCount; i++)
                {
                    if (_spawnedCount >= _maxSpawnCount)
                    {
                        break;
                    }

                    Transform selectedSpawnPoint = _spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)];
                    Dice dice = _diceFactory.Get((DiceType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(DiceType)).Length));
                    dice.SetAbilityMediator(_abilityMediator);
                    dice.transform.localScale = new Vector3(BaseScale, BaseScale, BaseScale);
                    dice.transform.SetParent(selectedSpawnPoint, false);
                    dice.MoveTo(selectedSpawnPoint.position);

                    _spawnedDices.Add(dice);
                    _spawnedCount++;
                }
                yield return new WaitForSeconds(_spawnCooldown);
            }

            SpawnFinished?.Invoke();
        }
        public void SpawnDice()
        {
            StopWork();

            _diceFactory = _locationProvaider.diceFactory;
            _spawnedCount = 0;
            _spawnedDices.Clear();
            
            if (gameObject.activeSelf)
            {
                _spawn = StartCoroutine(Spawn());
            }
        }

        public void StopWork()
        {
            if (_spawn != null)
                StopCoroutine(_spawn);
        }

    }
}
