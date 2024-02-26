using UnityEngine;

namespace VD
{
    public class StartGameState : StateMachineBehavior
    {
        [SerializeField] private LocationHandler _locationHandler;
        protected override void OnEnter()
        {
            _locationHandler.StartWork();
        }

        protected override void OnExit()
        {

        }

    }
}
