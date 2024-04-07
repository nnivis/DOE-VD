using UnityEngine;

namespace VD
{
    public class TransitionSceneMediator : MonoBehaviour
    {
        [SerializeField] MainSceneMode _mainSceneMode;
        [SerializeField] WipeController _wipeController;

        private SceneType _currentSceneType;

        private void Start()
        {
            _wipeController.TransitionCompleted += OnTransitionCompleted;
        }

        private void OnDestroy()
        {
            _wipeController.TransitionCompleted -= OnTransitionCompleted;
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

        public void ChangeState(SceneType sceneType)
        {
            _currentSceneType = sceneType;
            _wipeController.AnimateOut();
        }
        public void ChangeStateStartGame()
        {
            _currentSceneType = SceneType.StartGame;
            _wipeController.AnimateOut();
        }
        public void ChangeStateSettings()
        {
            _currentSceneType = SceneType.Settings;
            _wipeController.AnimateOut();
        }
    }
}
