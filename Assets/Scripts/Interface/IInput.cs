using System;
using UnityEngine;

namespace VD
{
    public interface IInput
    {
        event Action<Vector3> ClickLeftDown;
        event Action<Vector3> ClickRightDown;
    }
}
