using UnityEngine;
using DG.Tweening;
public class MoveUpDownComponent : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveDuration = 2f;

    void Start()
    {
        MoveUpDownAnimation();
    }

    void MoveUpDownAnimation()
    {
        transform.DOMoveY(transform.position.y + moveDistance, moveDuration)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
