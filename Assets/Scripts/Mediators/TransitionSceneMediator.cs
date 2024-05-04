using System;

namespace VD
{
    public class TransitionSceneMediator
    {
        public Action<SceneType> OnTransitionScene;

        public void NotifyTransition(SceneType sceneType)
        {
            OnTransitionScene?.Invoke(sceneType);
        }
    }
}
