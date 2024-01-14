using UnityEngine;
using Zenject;

namespace VD
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        private PlayerStateMachine _stateMachine;
        private MoveTowardsCursor _moveCursor;

        [Inject]
        private void Construct(InputHandler inputHandler)
        {
            _stateMachine = new PlayerStateMachine(this, transform.GetChild(0).gameObject, transform.GetChild(1).gameObject);
            _moveCursor = new MoveTowardsCursor();

            inputHandler.ClickDown += OnClickDown;
        }

        private void Update()
        {
            _moveCursor.MoveTowards(transform, _mainCamera);
        }
        private void OnClickDown(Vector3 cursorPosition)
        {

            _stateMachine.CurrentState.HandleClick(cursorPosition);
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


    }
}
