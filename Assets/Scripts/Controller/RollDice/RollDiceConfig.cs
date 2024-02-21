using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VD
{
    [CreateAssetMenu(fileName = "RollDice", menuName = "Config/RollDiceConfig", order = 3)]
    public class RollDiceConfig : ScriptableObject
    {
       [SerializeField] private  RollDice _rollDice;
       [SerializeField] private int _numberOfFaces;
       [SerializeField] private Sprite _background;
       [SerializeField] private Sprite _numberIcon;
       public RollDice RollDice => _rollDice;
       public int NumberOfFaces => _numberOfFaces;
       public Sprite Background => _background;
       public Sprite NumberIcon => _numberIcon; 
    }
}
