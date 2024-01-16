using UnityEngine;
using Zenject;

namespace VD
{
    public class Player : MonoBehaviour
    {
        InputHandler _inputHandler;
        [SerializeField] private Camera _mainCamera;
        private PlayerStateMachine _stateMachine;
        private MoveTowardsCursor _moveCursor;

        [Inject]
        private void Construct(InputHandler inputHandler)
        {
            _inputHandler = inputHandler;

            Cursor.lockState = CursorLockMode.None;

            _stateMachine = new PlayerStateMachine(transform.GetChild(0).gameObject, transform.GetChild(1).gameObject);
            _moveCursor = new MoveTowardsCursor();

            _inputHandler.ClickLeftDown += OnClickLeftDown;
            _inputHandler.ClickRightDown += OnClickRightDown;
        }

        private void Update()
        {
            _moveCursor.MoveTowards(transform, _mainCamera);
        }
        private void OnClickLeftDown(Vector3 cursorPosition)
        {
            _stateMachine.CurrentState.HandleLeftClick(cursorPosition);
        }

        private void OnClickRightDown(Vector3 cursorPosition)
        {
            _stateMachine.CurrentState.HandleRightClick(cursorPosition);
        }

        void OnTriggerEnter(Collider other)
        {
            _stateMachine.CurrentState.HandleTriggerEnter(other);
        }

        void OnTriggerExit(Collider other)
        {
            _stateMachine.CurrentState.HandleTriggerExit();
        }

        void OnCollisionStay(Collision collision)
        {
            _stateMachine.SwitchState<ActivePlayerState>();
        }

        void OnCollisionExit(Collision collision)
        {
            _stateMachine.SwitchState<PassiveState>();
        }

        void OnDisable()
        {
            _inputHandler.ClickLeftDown -= OnClickLeftDown;
            _inputHandler.ClickRightDown -= OnClickRightDown;
        }
    }
}
