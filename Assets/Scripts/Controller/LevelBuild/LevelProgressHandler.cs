using System;
using UnityEngine;
using Zenject;

namespace VD
{
    public class LevelProgressHandler : MonoBehaviour
    {
        [SerializeField] private LevelProgressPanel _levelProgressPanel;
        [SerializeField] private RollDicePanel _rollDicePanel;
        [SerializeField] private BlockContent _blockContent;
        [SerializeField] private ProgressGameMediator _progressGameMediator;
        private const int _indexDefaultPartLevel = 2;
        private int _currentNumberOfPartLevel;
        private int _numberOfPartLevel;
        private MainSceneMode _mainSceneMode;
        private ILocationProvaider _locationProvaider;
        private ILevelProvaider _levelProvaider;
        [Inject]
        private void Construct(ILocationProvaider locationProvaider)
        {
            _locationProvaider = locationProvaider;
        }

        public void Initialize(MainSceneMode mainSceneMode)
        {
            _mainSceneMode = mainSceneMode;

            _levelProgressPanel.Initialization(_blockContent);
            _levelProgressPanel.OnLevelBuild += UpdateProgressLevle;
            _levelProgressPanel.OnAnimationComplete += TransitionLevel;

            _rollDicePanel.OnGenereteRollDiceDone += BuildLevel;
            _rollDicePanel.Initialize(_locationProvaider);
        }

        private void TransitionLevel()
        {
             _mainSceneMode.GotoMainGameFight();
        }

        private void BuildLevel(int numberOfPartLevel)
        {
            _numberOfPartLevel = numberOfPartLevel + _indexDefaultPartLevel;

            ResetCurrentLevel();

            _rollDicePanel.gameObject.SetActive(false);
            _levelProgressPanel.gameObject.SetActive(true);
            _levelProgressPanel.BuildLevel(numberOfPartLevel);
        }
        private void ResetCurrentLevel()
        {
            _currentNumberOfPartLevel = 1;
        }

        public void ClearLevel()
        {
            ResetCurrentLevel();
            _levelProgressPanel.Clear();
            _rollDicePanel.Clear();
        }

        public void UpdateProgressLevle()
        {
            Debug.Log(_numberOfPartLevel);
            Debug.Log(_currentNumberOfPartLevel);

            if (_currentNumberOfPartLevel == _numberOfPartLevel)
            {
                _progressGameMediator.LevelComplete();
                _rollDicePanel.gameObject.SetActive(true);
                _levelProgressPanel.gameObject.SetActive(false);

                ClearLevel();

                _mainSceneMode.GotoStartGame();
            }
            else
            {
                Debug.Log("jjj");
                _currentNumberOfPartLevel++;
                _levelProgressPanel.MoveCharacterLevel(_levelProvaider.currentLevelPartIndex);
                
               
            }
        }



        public void StartWork()
        {
        }

    }
}
