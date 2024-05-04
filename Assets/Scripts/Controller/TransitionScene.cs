using System;
using UnityEngine;
using Zenject;

namespace VD
{
    public class TransitionScene : MonoBehaviour
    {
        public Action OnTransitionOutComplete;
        [SerializeField] MainSceneMode _mainSceneMode;
        [SerializeField] WipeController _wipeController;
        private TransitionSceneMediator _transitionSceneMediator;
        private SceneType _currentSceneType;

        [Inject]
        private void Construct(TransitionSceneMediator transitionSceneMediator)
        {
            _transitionSceneMediator = transitionSceneMediator;
            _transitionSceneMediator.OnTransitionScene += ChangeState;
        }

        private void OnEnable()
        {
            _wipeController.TransitionCompleted += OnTransitionCompleted;
        }

        private void OnDestroy()
        {
            _wipeController.TransitionCompleted -= OnTransitionCompleted;
        }
        private void ChangeState(SceneType sceneType)
        {
            _currentSceneType = sceneType;
            _wipeController.AnimateOut();
        }
        private void OnTransitionCompleted()
        {
            switch (_currentSceneType)
            {
                case SceneType.StartGame:
                    _mainSceneMode.GotoStartGame();
                    break;
                case SceneType.GameFight:
                    _mainSceneMode.GotoMainGameFight();
                    break;
                case SceneType.LevelProgress:
                    _mainSceneMode.GotoLevelBuild();
                    break;
                case SceneType.Settings:
                    _mainSceneMode.GotoSettings();
                    break;
                case SceneType.EndGame:
                    _mainSceneMode.GotoEndGame();
                    break;
                case SceneType.WinGame:
                    _mainSceneMode.GotoWinGame();
                    break;
                default:
                    Debug.LogWarning("Unknown scene type.");
                    break;
            }
            _wipeController.AnimateIn();
        }
    }
}
