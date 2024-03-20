using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterView : MonoBehaviour
{
    private const float MoveDistancePercentage = 0.33f;
    private const float AppearDuration = 1.0f;
    private const float MoveDuration = 1.0f;

    [SerializeField] private Image _visualImage;
    private RectTransform _visualTransform;

    private List<Vector3> _blockPositions = new List<Vector3>();

    public void Initialization(List<Vector3> blockPositions)
    {
        _blockPositions = blockPositions;
        _visualTransform = GetComponent<RectTransform>();
    }

    public void StartAnimation()
    {
        Sequence sequence = DOTween.Sequence();

        Vector3 initialPosition = _blockPositions.Count > 0 ? _blockPositions[0] : Vector3.zero;
        initialPosition += new Vector3(-0.0f,210.5f, 0.0f); // Ваше смещение по X и Y

        _visualTransform.anchoredPosition = initialPosition;

        Debug.Log("Initial Position: " + initialPosition);

        _visualImage.color = new Color(_visualImage.color.r, _visualImage.color.g, _visualImage.color.b, 0f);
        sequence.Append(_visualImage.DOFade(1f, AppearDuration));

        if (_blockPositions.Count > 10)
        {
            Vector3 targetPosition = _blockPositions[1];
            float moveDistance = Mathf.Abs(targetPosition.x - initialPosition.x) * MoveDistancePercentage;
            Vector3 intermediatePosition = new Vector3(targetPosition.x > initialPosition.x ? initialPosition.x + moveDistance : initialPosition.x - moveDistance, initialPosition.y, initialPosition.z);

            Debug.Log("Target Position: " + targetPosition);
            Debug.Log("Intermediate Position: " + intermediatePosition);

            sequence.Append(_visualTransform.DOAnchorPos(intermediatePosition, MoveDuration / 2).SetEase(Ease.OutCubic));
            sequence.Join(_visualTransform.DOAnchorPos(targetPosition, MoveDuration / 2).SetEase(Ease.InCubic));
        }
    }
}
