using System;
using UnityEngine;

namespace VD
{
    public class InputHandler : IDisposable
    {
        private IInput _input;

        public InputHandler(IInput input)
        {
            _input = input;
            _input.ClickDown += OnClickDown;
        }

        private void OnClickDown(Vector3 vector)
        {
            Debug.Log("ClickDown");
        }

        public void Dispose()
        {
            _input.ClickDown -= OnClickDown;
        }
    }
}
