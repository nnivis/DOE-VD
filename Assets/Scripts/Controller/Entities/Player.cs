using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace VD
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        private InputHandler _inputHandler;
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
        private void OnDisable()
        {
            _inputHandler.ClickLeftDown -= OnClickLeftDown;
            _inputHandler.ClickRightDown -= OnClickRightDown;
        }

        private void Update()
        {
            _moveCursor.MoveTowards(transform, _mainCamera);

            if (CheckRaycast())
            {
                _stateMachine.SwitchState<ActivePlayerState>();
            }
            else
            {
                _stateMachine.SwitchState<PassiveState>();
            }
        }

        private bool CheckRaycast()
        {
            Vector2 rayOrigin = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero);
            return hit.collider != null;
        }

        private void OnClickLeftDown(Vector3 cursorPosition)
        {

            _stateMachine.CurrentState.HandleLeftClick();
        }

        private void OnClickRightDown(Vector3 cursorPosition)
        {
            _stateMachine.CurrentState.HandleRightClick();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _stateMachine.CurrentState.HandleTriggerEnter2D(other);
        }

    }
}
