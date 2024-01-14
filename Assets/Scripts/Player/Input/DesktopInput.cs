using System;
using UnityEngine;
using Zenject;

namespace VD
{
    public class DesktopInput : IInput, ITickable
    {
        public event Action<Vector3> ClickDown;
        private const int LeftMouseButton = 0;

        public void Tick()
        {
            ProcessClickDown();
        }

        private void ProcessClickDown()
        {
            if (Input.GetMouseButtonDown(LeftMouseButton))
            {
                ClickDown?.Invoke(Input.mousePosition);
            }
        }

    }
}
