using System;

namespace VD
{
    public class GamePlayMediator 
    {
        public Action<GameFightEndReason> OnGameOver;

        public void NotifyGameOver(GameFightEndReason gameOverType)
        {
            OnGameOver?.Invoke(gameOverType);
        }
    }
}
