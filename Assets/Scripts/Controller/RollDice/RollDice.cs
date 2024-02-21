using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VD
{
    public class RollDice : MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private List<Image> _numberIcons;
        private int _numberOfFaces;

        public void Initialize(Sprite background, Sprite numberIcon, int numberOfFaces)
        {
            _background.sprite = background;
            SetIcons(numberIcon);
        }

        private void SetIcons(Sprite numberIcon)
        {
            foreach (Image icon in _numberIcons)
            {
                icon.sprite = numberIcon;
            }
        }
    }


}

