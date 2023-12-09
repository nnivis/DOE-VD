using DG.Tweening;
using UnityEngine;

public class DownUpScaleTweenAnimationStrategy : IUIAnimationStrategy
{
    private const float _scaleAmount = 1.1f;
    private const float _originalScale = 1.0f;

    public void AnimateIn(RectTransform rectTransform, float duration, float yOffset, Ease easeType)
    {
        DOTween.Kill(rectTransform);

        Vector3 originalPosition = rectTransform.anchoredPosition;
        rectTransform.anchoredPosition = new Vector3(originalPosition.x, yOffset, originalPosition.z);

        rectTransform.DOAnchorPosY(originalPosition.y, duration).SetEase(easeType)
            .OnComplete(() => OnMoveDownComplete(rectTransform, duration));

    }

    public void AnimateOut(RectTransform rectTransform, float duration, float yOffset, Ease easeType)
    {

    }

    private void OnMoveDownComplete(RectTransform rectTransform, float duration)
    {
        float _scaleAmount = 1.2f;

        rectTransform.DOScale(_scaleAmount, duration / 2).SetEase(Ease.InOutQuad)
            .OnComplete(() => OnScaleComplete(rectTransform, duration));
    }

    private void OnScaleComplete(RectTransform rectTransform, float duration)
    {

        float _originalScale = 1f;

        rectTransform.DOScale(_originalScale, duration / 2).SetEase(Ease.InOutQuad)
            .OnComplete(() => OnOriginalScaleComplete(rectTransform, duration));
    }

    private void OnOriginalScaleComplete(RectTransform rectTransform, float duration)
    {
        float _scaleAmount = 1.2f;

        rectTransform.DOScale(_scaleAmount, duration / 2).SetEase(Ease.InOutQuad)
            .OnComplete(() => OnNextScaleComplete(rectTransform, duration));
    }

    private void OnNextScaleComplete(RectTransform rectTransform, float duration)
    {
        float _originalScale = 1f;

        rectTransform.DOScale(_originalScale, duration / 2).SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo); 
    }
}
