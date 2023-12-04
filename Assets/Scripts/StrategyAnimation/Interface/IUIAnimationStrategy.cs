using DG.Tweening;
using UnityEngine;

public interface IUIAnimationStrategy
{
    void AnimateIn(RectTransform rectTransform, float duration, float yOffset, Ease easeType);
    void AnimateOut(RectTransform rectTransform, float duration, float yOffset, Ease easeType);
}
