using UnityEngine;
using DG.Tweening;

public class UIStartGameAnimationState : MonoBehaviour
{
    [SerializeField] private RectTransform _logoRectTransform;
    [SerializeField] private RectTransform _buttonRectTransform;
    private UIAnimationHandler _uiAnimationHandler;
    private const float _yOffsetLogo = 700.0f;
    private const float _yOffsetButton = -760.0f;
    private const float _duration = 3.0f;
    private Ease _easeType;

    public void Setup()
    {
        _uiAnimationHandler = GetComponentInParent<UIAnimationHandler>();
    }

    public void StartAnimation()
    {

        _uiAnimationHandler.SetAnimationStrategy(new DownUpScaleTweenAnimationStrategy());
        _uiAnimationHandler.AnimateIn(_logoRectTransform, _duration, _yOffsetLogo, _easeType);

        _uiAnimationHandler.SetAnimationStrategy(new DownUpTweenAnimationStrategy());
        _uiAnimationHandler.AnimateIn(_buttonRectTransform, _duration, _yOffsetButton, _easeType);
    }

    public void StopAnimation()
    {
        _uiAnimationHandler.SetAnimationStrategy(new DownUpTweenAnimationStrategy());
        _uiAnimationHandler.AnimateOut(_logoRectTransform, _duration, _yOffsetLogo, _easeType);

        _uiAnimationHandler.SetAnimationStrategy(new DownUpTweenAnimationStrategy());
        _uiAnimationHandler.AnimateOut(_buttonRectTransform, _duration, _yOffsetButton, _easeType);
    }

}
