using UnityEngine;

namespace VD
{
    public class GameFightViewMediator : MonoBehaviour
    {
        [SerializeField] private GameFightView _gameFightView;
        public void UpdateTimerInfo(float defaultTimer, float currentTimer)
        {
            _gameFightView.UpdateTimerInfo(defaultTimer, currentTimer);
        }
    }
}
