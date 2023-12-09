using UnityEngine;

namespace VD
{
    public class BootstrapGame : MonoBehaviour
    {

        [SerializeField] private UIStateMachineManager _stateMachine;

        private void Awake()
        {
            //InitializStateMachine();
        }

        private void InitializStateMachine()
        {
            _stateMachine.SetupStateMachine();
            _stateMachine.StartStateMachine();
        }

    }
}