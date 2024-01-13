using System;
using UnityEngine;

namespace VD
{
    public interface IInput
    {
        event Action<Vector3> ClickDown;
    }
}
