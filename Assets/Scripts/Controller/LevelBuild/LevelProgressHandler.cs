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
        private bool _isLevelBuild = false;
        private TransitionSceneMediator _transitionSceneMediator;
        private ILocationProvaider _locationProvaider;
        private ILevelProvaider _levelProvaider;

        [Inject]
        private void Construct(ILocationProvaider locationProvaider)
        {
            _locationProvaider = locationProvaider;
        }

        public void Initialize(TransitionSceneMediator transitionSceneMediator)
        {
            _transitionSceneMediator = transitionSceneMediator;

            _levelProgressPanel.Initialization(_blockContent);
            _levelProgressPanel.OnLevelBuild += UpdateProgressLevle;
            _levelProgressPanel.OnAnimationComplete += TransitionLevel;

            _rollDicePanel.OnGenereteRollDiceDone += BuildLevel;
            _rollDicePanel.Initialize(_locationProvaider);
        }

        private void TransitionLevel()
        {
            _transitionSceneMediator.ChangeState(SceneType.GameFight);
        }

        private void BuildLevel(int numberOfPartLevel)
        {
            _isLevelBuild = true;

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
            if (_currentNumberOfPartLevel == _numberOfPartLevel)
            {
              
                _progressGameMediator.LevelComplete();
                _rollDicePanel.gameObject.SetActive(true);
                _levelProgressPanel.gameObject.SetActive(false);

                ClearLevel();

                _transitionSceneMediator.ChangeState(SceneType.StartGame);
            }
            else
            {
                _currentNumberOfPartLevel++;
                _levelProgressPanel.MoveCharacterLevel(_currentNumberOfPartLevel);
            }
        }
        public void DestroyLevel()
        {

        }
        public void StartWork()
        {
            if (_isLevelBuild)
                UpdateProgressLevle();
        }

    }
}
