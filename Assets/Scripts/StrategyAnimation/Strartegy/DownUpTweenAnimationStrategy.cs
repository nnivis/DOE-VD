using DG.Tweening;
using UnityEngine;

public class DownUpTweenAnimationStrategy : IUIAnimationStrategy
{
    public void AnimateIn(RectTransform rectTransform, float duration, float yOffset, Ease easeType)
    {

        Vector3 originalPosition = rectTransform.anchoredPosition;
        rectTransform.anchoredPosition = new Vector3(originalPosition.x, yOffset, originalPosition.z);

        rectTransform.DOAnchorPosY(originalPosition.y, duration).SetEase(easeType)
            .OnComplete(() => { });

    }

    public void AnimateOut(RectTransform rectTransform, float duration, float yOffset, Ease easeType)
    {
        DOTween.Kill(rectTransform);

        Vector3 originalPosition = rectTransform.anchoredPosition;
        rectTransform.DOAnchorPosY(yOffset, duration).SetEase(easeType)
            .OnComplete(() => { });
    }

}
