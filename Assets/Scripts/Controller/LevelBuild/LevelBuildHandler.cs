using UnityEngine;
using Zenject;

namespace VD
{
    public class LevelBuildHandler : MonoBehaviour
    {
        [SerializeField] private LevelBuildPanel _levelBuildPanel;
        [SerializeField] private RollDicePanel _rollDicePanel;
        [SerializeField] private BlockContent _blockContent;
        private ILocationProvaider _locationProvaider;
        [Inject]
        private void Construct(ILocationProvaider locationProvaider)
        {
            _locationProvaider = locationProvaider;
            _levelBuildPanel.Initialization(_blockContent);
        }

        public void StartWork()
        {
            _rollDicePanel.Initialize(_locationProvaider);
        }

        public void BuildLevel(int numberOfLevel)
        {
            Debug.Log(numberOfLevel);
            _rollDicePanel.gameObject.SetActive(false);
            _levelBuildPanel.gameObject.SetActive(true);
            
            _levelBuildPanel.BuildLevel(numberOfLevel);
        }



    }
}
