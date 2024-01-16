using UnityEngine;

namespace VD
{
    public class ActivePlayerState : IPlayerState
    {
        private readonly GameObject _activePrefab;
        private Dice _dice;

        public ActivePlayerState(PlayerStateMachine playerStateMachine, GameObject activePrefab)
        {
            _activePrefab = activePrefab;
        }

        public void Enter()
        {
            _activePrefab.SetActive(true);
        }

        public void Exit()
        {
            _activePrefab.SetActive(false);
        }

        public void HandleLeftClick(Vector3 position)
        {
            if (_dice != null)
            {
                _dice.OnMassegeDiceLeftClick();
            }
        }

         public void HandleRightClick(Vector3 position)
        {
            if (_dice != null)
            {
                _dice.OnMassegeDiceRightClick();
            }
        }

        public void HandleTriggerEnter(Collider other)
        {
            Dice diceComponent = other.GetComponent<Dice>();

            if (diceComponent != null)
            {
                _dice = diceComponent;
            }

        }

        public void HandleTriggerExit()
        {
            _dice = null;
        }

    }
}
