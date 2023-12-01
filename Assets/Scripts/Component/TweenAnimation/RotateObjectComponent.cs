using DG.Tweening;
using UnityEngine;

public class RotateObjectComponent : MonoBehaviour
{
    public enum RotationDirection
    {
        Clockwise,
        Counterclockwise
    }

    [SerializeField] private RotationDirection rotationDirection = RotationDirection.Clockwise;
    [SerializeField] private float rotationDuration = 2f;

    private void Start()
    {
        RotateObject();
    }

    //[ContextMenu("Rotate")]
    private void RotateObject()
    {
        float targetRotation = (rotationDirection == RotationDirection.Clockwise) ? 360f : -360f;
        transform.DORotate(new Vector3(0f, 0f, targetRotation), rotationDuration, RotateMode.FastBeyond360)
            .SetLoops(-1)
            .SetEase(Ease.Linear);
    }
}
