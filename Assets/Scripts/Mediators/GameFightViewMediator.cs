using UnityEngine;

namespace VD
{
    public class GameFightViewMediator : MonoBehaviour
    {
        [SerializeField] GameFightPanel _gameFightPanel;
        public void UpdateTimerInfo(float defaultTimer, float currentTimer)
        {
            _gameFightPanel.UpdateTimerView(defaultTimer, currentTimer);
        }
    }
}
