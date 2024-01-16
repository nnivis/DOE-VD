using System;
using UnityEngine;
using Zenject;

namespace VD
{
    public class DesktopInput : IInput, ITickable
    {
        public event Action<Vector3> ClickLeftDown;
        public event Action<Vector3> ClickRightDown;
        private const int LeftMouseButton = 0;
        private const int RightMouseButton = 1;

        public void Tick()
        {
            ProcessLeftClickDown();
            ProcessRightClickDown();
        }

        private void ProcessLeftClickDown()
        {
            if (Input.GetMouseButtonDown(LeftMouseButton))
            {
                ClickLeftDown?.Invoke(Input.mousePosition);
            }
        }

        private void ProcessRightClickDown()
        {
            if (Input.GetMouseButtonDown(RightMouseButton))
            {
                ClickRightDown?.Invoke(Input.mousePosition);
            }
        }

    }
}
