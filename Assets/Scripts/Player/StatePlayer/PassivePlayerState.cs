using UnityEngine;

namespace VD
{
    public class PassiveState : IPlayerState
    {
        private readonly GameObject _passivePrefab;

        public PassiveState(PlayerStateMachine playerStateMachine, GameObject passivePrefab)
        {
            _passivePrefab = passivePrefab;
        }

        public void Enter()
        {
            _passivePrefab.SetActive(true);
        }

        public void Exit()
        {
            _passivePrefab.SetActive(false);
        }

        public void HandleLeftClick(Vector3 position)
        {
            //Debug.Log("Passive state click");
        }

        public void HandleRightClick(Vector3 position)
        {
            //Debug.Log("Passive state click");
        }
        public void HandleTriggerEnter(Collider other)
        {

            //Debug.Log("Passive state trigger enter. Assigned _dice.");

        }

        public void HandleTriggerExit()
        {

        }

    }
}
