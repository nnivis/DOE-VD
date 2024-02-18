using System;
using UnityEngine;

namespace VD
{
    public class GamePlayMediator 
    {
        public Action<GameFightEndReason> OnGameOver;

        public void NotifyGameOver(GameFightEndReason gameOverType)
        {
            Debug.Log("s");
            OnGameOver?.Invoke(gameOverType);
        }
    }
}
