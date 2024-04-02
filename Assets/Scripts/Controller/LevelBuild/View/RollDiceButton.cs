using System;
using UnityEngine;
using UnityEngine.UI;

namespace VD
{
    public class RollDiceButton : MonoBehaviour
    {
        public Action OnActiveRollDiceClicked;
        [SerializeField] private Button _rollDiceButton;

        private void OnEnable()
        {
            _rollDiceButton.onClick.AddListener(OnActiveRollDiceButtonClicked);
        }

        private void OnDisable()
        {
            _rollDiceButton.onClick.RemoveListener(OnActiveRollDiceButtonClicked);
        }
        private void OnActiveRollDiceButtonClicked()
        {
            if (OnActiveRollDiceClicked != null)
                OnActiveRollDiceClicked();
        }

        public void DeactivateRollDiceButton()
        {
            gameObject.SetActive(false);
        }

        public void ActiveRollDiceButton()
        {
            gameObject.SetActive(true);
        }

    }
}
