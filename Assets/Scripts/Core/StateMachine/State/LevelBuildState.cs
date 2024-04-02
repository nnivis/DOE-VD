using UnityEngine;

namespace VD
{
    public class LevelBuildState : StateMachineBehavior
    {
        [SerializeField] private LevelProgressHandler _levelProgressHandler;

        protected override void OnEnter()
        {
            _levelProgressHandler.StartWork();
        }

        protected override void OnExit()
        {

        }
    }
}
