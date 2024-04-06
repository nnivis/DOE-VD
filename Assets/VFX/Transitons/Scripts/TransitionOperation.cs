using System;

namespace Project.Infrastracture.UI.Transitions
{
    public class TransitionOperation : ITransitionOperation
    {
        public event Action OnCompleted;
        
        public void Complete()
        {
            OnCompleted?.Invoke();
        }
    }
}