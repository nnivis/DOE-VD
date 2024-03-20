using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace VD
{
    public class RollDiceView : MonoBehaviour
    {
        public Action<int> OnNumberOfLevels;
        [SerializeField] private Image _background;
        [SerializeField] private Transform _parentNumberIcons;
        private GameObject _iconIndexPrefab;
        private int _indexOfFaces;

        public void Initialize(RollDiceConfig rollDiceConfig)
        {
            _indexOfFaces = rollDiceConfig.IndexOfFaces;
            _background.sprite = rollDiceConfig.Background;
            _iconIndexPrefab = rollDiceConfig.IconIndexPrefab;
        }

        public void ActivateRollDiceView()
        {
            gameObject.SetActive(true);
            StartCoroutine(SpawnIconsOverTime(1));
        }

        private IEnumerator SpawnIconsOverTime(float duration)
        {
            float timer = 0f;
            while (timer < duration)
            {
                int numberOfLevels = UnityEngine.Random.Range(1, _indexOfFaces + 1);
                SpawnIcon(numberOfLevels);
                timer++;
                yield return new WaitForSeconds(0.1f);
            }

            GenerateNumberOfLevel();
        }

        private void GenerateNumberOfLevel()
        {
            int numberOfLevels = UnityEngine.Random.Range(1, _indexOfFaces + 1);
            SpawnIcon(numberOfLevels);
            StartCoroutine(NumberOfLevels(numberOfLevels));
        }
        private IEnumerator NumberOfLevels(int numberOfLevels)
        {
            yield return new WaitForSeconds(1.0f);
            OnNumberOfLevels?.Invoke(numberOfLevels);
        }
        private void SpawnIcon(int numberOfLevels)
        {
            foreach (Transform child in _parentNumberIcons)
            {
                Destroy(child.gameObject);
            }
            for (int i = 0; i < numberOfLevels; i++)
            {
                GameObject newIcon = Instantiate(_iconIndexPrefab, _parentNumberIcons);
                newIcon.transform.localScale = Vector3.one;
            }
        }
        public void DeactivateRollDiceView()
        {
            gameObject.SetActive(false);
        }
    }
}
