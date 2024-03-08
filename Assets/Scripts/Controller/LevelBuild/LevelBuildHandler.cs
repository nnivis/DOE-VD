using UnityEngine;
using Zenject;

namespace VD
{
    public class LevelBuildHandler : MonoBehaviour
    {
        private LevelBuildPanel _levelBuildPanel;
        private RollDicePanel _rollDicePanel;
        private ILocationProvaider _locationProvaider;
        [Inject]
        private void Construct(ILocationProvaider locationProvaider)
        {
            _locationProvaider = locationProvaider;
        }
        public void StartBuildingLevel()
        {
            
        }
    }
}
