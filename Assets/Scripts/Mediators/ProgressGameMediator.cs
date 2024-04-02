using UnityEngine;

namespace VD
{
    public class ProgressGameMediator : MonoBehaviour
    {
        [SerializeField] private LocationHandler _locationHandler;
        [SerializeField] private LevelProgressHandler _levelProgressHandler;

        public void ActiveLevel(int levelIndex)
        {
            _locationHandler.ActiveLevel(levelIndex);
        }

        public void LevelComplete()
        {
            _locationHandler.PassLevel();
        }
    }
}
