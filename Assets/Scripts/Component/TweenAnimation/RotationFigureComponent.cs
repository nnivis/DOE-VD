using UnityEngine;
using DG.Tweening;

public class RotationFigureComponent : MonoBehaviour
{
    public float rotationDuration = 2f; // Длительность вращения в секундах

    void Start()
    {
        RotateClockwiseAnimation();
    }

    void RotateClockwiseAnimation()
    {
        // Используем DOTween для плавного вращения объекта
        transform.DORotate(new Vector3(0f, 360f, 0), rotationDuration, RotateMode.LocalAxisAdd)
            .SetLoops(-1, LoopType.Restart) // Бесконечный цикл
            .SetEase(Ease.Linear); // Линейное вращение
    }
}
