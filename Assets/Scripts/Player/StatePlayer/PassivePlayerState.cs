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



        public void HandleLeftClick()
        {
            Debug.Log("Passive");
        }


        public void HandleRightClick()
        {
            Debug.Log("Passive");
        }

        public void HandleTriggerEnter2D(Collider2D collider)
        {

        }

        public void HandleTriggerExit2D()
        {

        }
    }
}
