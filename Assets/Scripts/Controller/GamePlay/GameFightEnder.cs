using UnityEngine;
using Zenject;

namespace VD
{
    public class GameFightEnder : MonoBehaviour
    {
        private GamePlayMediator _gamePlayMediator;
        [Inject]
        private void Construct(GamePlayMediator gamePlayMediator)
        {
            _gamePlayMediator = gamePlayMediator;
        }

        private void OnEnable()
        {
            _gamePlayMediator.OnGameOver += GameFightOver;
        }
        private void OnDisable()
        {
            _gamePlayMediator.OnGameOver -= GameFightOver;
        }
        private void GameFightOver(GameFightEndReason reason)
        {


        }
    }
}
