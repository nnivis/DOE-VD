using UnityEngine;
using UnityEngine.UI;

namespace VD
{
    public class ActivePlayerState : IPlayerState
    {
        private readonly Player _player;
        private readonly GameObject _activePrefab;
        private Dice _dice;

        public ActivePlayerState(PlayerStateMachine playerStateMachine, Player player, GameObject activePrefab)
        {
            _player = player;
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

        public void HandleClick(Vector3 position)
        {
            if (_dice != null)
            {
                _dice.OnMassegeDice();
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

        public void Update()
        {

        }

    }
}
