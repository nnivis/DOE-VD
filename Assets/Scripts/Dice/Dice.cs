using UnityEngine;
using UnityEngine.UI;

namespace VD
{
    public class Dice : MonoBehaviour
    {
        private Sprite _icon;
        private int _value;
        private DiceType _currentType;
        private IDiceConfigProvider _configProvider;
        public void Initialize(IDiceConfigProvider configProvider, Sprite icon, int value, DiceType type)
        {
            _configProvider = configProvider;

            _icon = icon;
            _value = value;
            _currentType = type;

            SetIcon(icon);
        }

        public void OnMassegeDiceLeftClick()
        {
            Debug.Log("Dice Left Click Massage");
        }

        public void OnMassegeDiceRightClick()
        {
            ChangeType();
        }

        public void ChangeType()
        {
            _currentType = _configProvider.GetNextType(_currentType);
            DiceConfig newConfig = _configProvider.GetConfig(_currentType);
            UpdateConfig(newConfig);

        }

        public void UpdateConfig(DiceConfig config)
        {
            _icon = config.Icon;
            _value = config.Value;
            _currentType = config.Type;

            SetIcon(_icon);
        }

        public void MoveTo(Vector3 position) => transform.position = position;
        public void SetIcon(Sprite sprite) => GetComponentInChildren<Image>().sprite = sprite;

    }



}

