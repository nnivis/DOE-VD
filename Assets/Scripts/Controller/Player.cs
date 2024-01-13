using UnityEngine;
using Zenject;

namespace VD
{
    public class Player : MonoBehaviour
    {
        private InputHandler _inputHandler;
        
        [Inject]
        private void Construct(InputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }
    }
}
