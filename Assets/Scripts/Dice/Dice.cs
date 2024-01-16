using System.Collections.Generic;
using UnityEngine;

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
            Debug.Log(_configProvider);
            
            _icon = icon;
            _value = value;
            _currentType = type;


        }

        public void OnMassegeDiceLeftClick()
        {
            Debug.Log("Dice Massage");
        }

        public void OnMassegeDiceRightClick()
        {
            Debug.Log("Dice Massage");
        }

        public void MoveTo(Vector3 position) => transform.position = position;
    }
}
