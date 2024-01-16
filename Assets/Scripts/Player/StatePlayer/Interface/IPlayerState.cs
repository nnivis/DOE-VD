using UnityEngine;
using UnityEngine.UI;

namespace VD
{
    public interface IPlayerState
    {
        void Enter();
        void Exit();
        void HandleLeftClick(Vector3 position);
        void HandleRightClick(Vector3 position);
        void HandleTriggerEnter(Collider other);
        void HandleTriggerExit();
    }
}
