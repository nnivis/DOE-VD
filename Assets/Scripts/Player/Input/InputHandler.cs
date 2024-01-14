using System;
using UnityEngine;

namespace VD
{
    public class InputHandler : IDisposable
    {
        private IInput _input;
        public Action<Vector3> ClickDown { get; internal set; }

        public InputHandler(IInput input)
        {
            _input = input;
            _input.ClickDown += OnClickDown;
        }

        private void OnClickDown(Vector3 vector)
        {
            ClickDown?.Invoke(vector);
        }

        public void Dispose()
        {
            _input.ClickDown -= OnClickDown;
        }
    }
}
