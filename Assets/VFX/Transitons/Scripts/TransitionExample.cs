using System.Collections;
using System.Collections.Generic;
using Project.Infrastracture.UI.Transitions;
using UnityEngine;

public class TransitionExample : MonoBehaviour
{
    [SerializeField] private TransitionScreen _circleTransition;
    [SerializeField] private TransitionScreen _diamondTransition;

    public void StartCircleTransition()
    {
        ITransitionOperation operation = _circleTransition.Enter();

        operation.OnCompleted += () =>
        {
            _circleTransition.Exit();
        };
    }
    
    public void StartDiamondTransition()
    {
        ITransitionOperation operation = _diamondTransition.Enter();
        
        operation.OnCompleted += () =>
        {
            _diamondTransition.Exit();
        };
    }
}
