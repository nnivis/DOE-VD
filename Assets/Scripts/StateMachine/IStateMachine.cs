using System.Collections.Generic;
using UnityEngine;

namespace VD
{
    public interface IStateMachine
    {
        void Init(StateMachine stateMachine);
        void Enter();
        void Exit();
        IReadOnlyList<GameObject> GetViews();
    }
}
