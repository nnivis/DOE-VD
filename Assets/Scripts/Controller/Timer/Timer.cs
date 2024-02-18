using System;
using UnityEngine;
using Zenject;

namespace VD
{
    public class Timer : MonoBehaviour
    {
        public Action<GameFightEndReason> onTimerUp;
        [SerializeField] private GameFightViewMediator _gameFightViewMediator;
        private const float _defaultTimer = 5f;
        private GamePlayMediator _gamePlayMediator;
        private GameFightEndReason _gameFightEndReason;
        private float _currentTimer;
        private bool _isTimerStart;
        public float CurrentTimer => _currentTimer;
        public float DefaultTimer => _defaultTimer;

        [Inject]
        private void Construct(GamePlayMediator gamePlayMediator)
        {
            _gamePlayMediator = gamePlayMediator;
            _gamePlayMediator.OnGameOver += HandleTimerExpiration;
            _gameFightEndReason = GameFightEndReason.TimeUp;

            _isTimerStart = false;
        }

        public void StartTimer()
        {
            _currentTimer = _defaultTimer;
            _isTimerStart = true;
        }
        private void OnDestroy()
        {
            _gamePlayMediator.OnGameOver -= HandleTimerExpiration;
        }
        private void Update()
        {
            if (_isTimerStart)
                UpdateTimer();
        }

        private void UpdateTimer()
        {
            if (_currentTimer > 0f)
            {
                _currentTimer -= Time.deltaTime;
                UpdateView();
                if (_currentTimer <= 0f)
                {
                    _currentTimer = 0f;
                    HandleTimerExpiration(_gameFightEndReason);
                    _isTimerStart = false;
                }
            }
        }

        private void UpdateView()
        {
            _gameFightViewMediator.UpdateTimerInfo(_defaultTimer, _currentTimer);
        }

        private void HandleTimerExpiration(GameFightEndReason reason)
        {
            onTimerUp?.Invoke(reason);
        }
    }
}
