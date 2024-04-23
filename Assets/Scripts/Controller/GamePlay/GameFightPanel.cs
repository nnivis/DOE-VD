using UnityEngine;

namespace VD
{
    public class GameFightPanel : MonoBehaviour
    {
        [SerializeField] private TimerView _timerView;
        public void UpdateTimerView(float defaultTimer, float currentTimer)
        {
            _timerView.UpdateTimerInfo(defaultTimer, currentTimer);
        }
    }
}
