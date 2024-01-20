using UnityEngine;
using UnityEngine.UI;

namespace VD
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Dice : MonoBehaviour
    {
        private Sprite _icon;
        private int _value;
        private DiceType _currentType;
        private IDiceConfigProvider _configProvider;
        private DiceMove _diceMove;
        private Rigidbody2D _rigidBody2D;

        public void Initialize(IDiceConfigProvider configProvider, Sprite icon, int value, DiceType type)
        {
            _configProvider = configProvider;
            _icon = icon;
            _value = value;
            _currentType = type;

            SetIcon(icon);

            _rigidBody2D = GetComponent<Rigidbody2D>();

            _diceMove = new DiceMove();
            _diceMove.Initialize(_rigidBody2D);
            _diceMove.AddStartingForce();
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

        public void OnMassegeDiceLeftClick()
        {
            Debug.Log("LEFT");
        }

        public void OnMassegeDiceRightClick()
        {
            Debug.Log("RIGHT");
            ChangeType();
        }

        public void MoveTo(Vector3 position) => transform.position = position;
        public void SetIcon(Sprite sprite) => GetComponentInChildren<Image>().sprite = sprite;
        public void FixedUpdate() => _diceMove.UpdateMovement();

    }

}

