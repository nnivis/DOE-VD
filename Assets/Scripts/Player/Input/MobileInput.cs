using System;
using UnityEngine;
using Zenject;

namespace VD
{
    public class MobileInput : IInput, ITickable
    {
        public event Action<Vector3> ClickDown;
        private const int FirstTouch = 0;

        public void Tick()
        {
            Touch touch = Input.GetTouch(FirstTouch);

            if(touch.phase == TouchPhase.Began)
            ClickDown?.Invoke(touch.position);
        }

    }
}
