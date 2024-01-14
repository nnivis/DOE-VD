using UnityEngine;
using UnityEngine.UI;

namespace VD
{
    public interface IPlayerState
    {
        void Enter();
        void Exit();
        void Update();
        void HandleClick(Vector3 position);
        void HandleTriggerEnter(Collider other);
          void HandleTriggerExit();
    }
}
