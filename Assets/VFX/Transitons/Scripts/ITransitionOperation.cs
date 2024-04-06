using System;

namespace Project.Infrastracture.UI.Transitions
{
    public interface ITransitionOperation
    {
        event Action OnCompleted;
    }
}