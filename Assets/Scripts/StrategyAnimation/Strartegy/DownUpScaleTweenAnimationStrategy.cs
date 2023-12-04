using DG.Tweening;
using UnityEngine;

public class DownUpScaleTweenAnimationStrategy : IUIAnimationStrategy
{
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
        float scaleAmount = 1.2f;

        rectTransform.DOScale(scaleAmount, duration / 2).SetEase(Ease.InOutQuad)
            .OnComplete(() => OnScaleComplete(rectTransform, duration));
    }

    private void OnScaleComplete(RectTransform rectTransform, float duration)
    {

        float originalScale = 1f;

        rectTransform.DOScale(originalScale, duration / 2).SetEase(Ease.InOutQuad)
            .OnComplete(() => OnOriginalScaleComplete(rectTransform, duration));
    }

    private void OnOriginalScaleComplete(RectTransform rectTransform, float duration)
    {
        // Здесь вы можете добавить логику для следующей анимации, например, следующего увеличения
        float nextScaleAmount = 1.2f;

        rectTransform.DOScale(nextScaleAmount, duration / 2).SetEase(Ease.InOutQuad)
            .OnComplete(() => OnNextScaleComplete(rectTransform, duration));
    }

    private void OnNextScaleComplete(RectTransform rectTransform, float duration)
    {
        // И так далее, можете добавить еще анимаций по необходимости
        float originalScale = 1f;

        rectTransform.DOScale(originalScale, duration / 2).SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo); // Здесь устанавливаем зацикленность с эффектом "Yoyo"
    }
}
