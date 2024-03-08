using UnityEngine;

namespace VD
{
    public class LevelBuildState : StateMachineBehavior
    {
        [SerializeField] private LevelBuildHandler _levelBuildHandler;

        protected override void OnEnter()
        {
            _levelBuildHandler.StartBuildingLevel();
        }

        protected override void OnExit()
        {

        }
    }
}
