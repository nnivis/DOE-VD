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

        public void HandleLeftClick()
        {
            if (_dice != null)
                _dice.OnMassegeDiceLeftClick();
        }

        public void HandleRightClick()
        {
            if (_dice != null)
                _dice.OnMassegeDiceRightClick();
        }

        public void HandleTriggerEnter2D(Collider2D collider)
        {
            GameObject colliderObject = collider.gameObject;
            Dice diceComponent = colliderObject.GetComponent<Dice>();

            if (diceComponent != null)
                _dice = diceComponent;
        }
    }
}
