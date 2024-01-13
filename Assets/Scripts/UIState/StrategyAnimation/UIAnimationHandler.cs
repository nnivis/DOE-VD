using DG.Tweening;
using UnityEngine;

public class UIAnimationHandler : MonoBehaviour
{
    private IUIAnimationStrategy _animationStrategy;
   
    public void SetAnimationStrategy(IUIAnimationStrategy strategy)
    {
        _animationStrategy = strategy;
    }

    public void AnimateIn(RectTransform _rectTransform, float duration, float yOffset, Ease easeType)
    {
        _animationStrategy.AnimateIn(_rectTransform, duration, yOffset, easeType);
    }

    public void AnimateOut(RectTransform _rectTransform, float duration, float yOffset, Ease easeType)
    {
        _animationStrategy.AnimateOut(_rectTransform, duration, yOffset, easeType);
    }
}
