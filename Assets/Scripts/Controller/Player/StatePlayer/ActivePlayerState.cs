using Unity.VisualScripting;
using UnityEngine;

namespace VD
{
    public class ActivePlayerState : IPlayerState
    {
        private readonly GameObject _activePrefab;
        private Dice _dice;
        private bool _isDice;

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
            Hedge hedgeComponent = colliderObject.GetComponent<Hedge>();

            if (hedgeComponent != null)
            {
                _isDice = false;
                return;
            }
            else if (diceComponent != null)
            {
                _dice = diceComponent;
            }
            _isDice = true;
        }

        public bool isDice()
        {
            return _isDice;
        }
    }
}
