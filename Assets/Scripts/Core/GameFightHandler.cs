using UnityEngine;

namespace VD
{
    public class GameFightHandler : MonoBehaviour
    {
        [SerializeField] private DiceSpawner _diceSpawner;
        [SerializeField] private CharacterSpawner _characterSpawner;

        public void StartGame()
        {
            SpawnComponent();
        }

        private void SpawnComponent()
        {
            _diceSpawner.StartWork();
            _characterSpawner.StartWork();
        }
    }
}
