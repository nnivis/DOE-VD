using UnityEngine;
using UnityEngine.UI;

namespace VD
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Dice : MonoBehaviour
    {
        private Sprite _icon;
        private int _valueAbility;
        private float _speed = 2.5f;
        private IDiceConfigProvider _configProvider;
        private IDiceAbility _currentAbility;
        private DiceType _currentType;
        private DiceMove _diceMove;
        private Rigidbody2D _rigidBody2D;

        public void Initialize(IDiceConfigProvider configProvider, Sprite icon, int valueAbility, DiceType type)
        {
            _configProvider = configProvider;
            _icon = icon;
            _valueAbility = valueAbility;
            _currentType = type;

            SetIcon(icon);

            _rigidBody2D = GetComponent<Rigidbody2D>();

            _diceMove = GetComponent<DiceMove>();
            _diceMove.Initialization(_rigidBody2D, _speed);
        }

        void Start()
        {
           _diceMove.AddStartingForce();
        }

        public void OnMassegeDiceLeftClick()
        {

        }

        public void ApplyCurrentAbility(GameObject target)
        {
            if (_currentAbility != null)
            {
                _currentAbility.ApplyAbility(target);
            }
        }

        public void OnMassegeDiceRightClick()
        {
            ChangeType();
        }

        public void ChangeType()
        {
            _currentType = _configProvider.GetRandomType(_currentType);
            DiceConfig newConfig = _configProvider.GetConfig(_currentType);
            UpdateConfig(newConfig);

            switch (_currentType)
            {
                case DiceType.AttackEnemy:
                    _currentAbility = new AttackEnemyAbility();
                    break;
                case DiceType.AttackPlayer:
                    _currentAbility = new AttackPlayerAbility();
                    break;
                case DiceType.Health:
                    _currentAbility = new HealthAbility();
                    break;
                default:
                    _currentAbility = null;
                    break;
            }
        }
        public void UpdateConfig(DiceConfig config)
        {
            _icon = config.Icon;
            _valueAbility = config.Value;
            _currentType = config.Type;

            SetIcon(_icon);
        }
        public void FixedUpdate() => _diceMove.UpdateMovement();
        public void SetIcon(Sprite sprite) => GetComponentInChildren<Image>().sprite = sprite;
        public void MoveTo(Vector3 position) => transform.position = position;

    }

}

