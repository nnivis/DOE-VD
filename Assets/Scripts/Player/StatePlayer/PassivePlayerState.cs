using UnityEngine.UI;
using UnityEngine;

namespace VD
{
    public class PassiveState : IPlayerState
    {
        private readonly Player _player;
        private readonly GameObject _passivePrefab;

        public PassiveState(PlayerStateMachine playerStateMachine, Player player, GameObject passivePrefab)
        {
            _player = player;
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

        public void HandleClick(Vector3 position)
        {
            //Debug.Log("Passive state click");
        }
        public void HandleTriggerEnter(Collider other)
        {

            //Debug.Log("Passive state trigger enter. Assigned _dice.");

        }

        public void HandleTriggerExit()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
        }

    }
}
