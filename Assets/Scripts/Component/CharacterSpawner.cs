using UnityEngine;

namespace VD
{
    public class CharacterSpawner : MonoBehaviour
    {

        [SerializeField] private CharacterConfig _config;
        [SerializeField] private Character _prefab;
        [SerializeField] private Transform _spawnPoint;
        private GamePlayMediator _gamePlayMediator;
        private const float BaseScale = 3.0f;

        private void Construct(GamePlayMediator gamePlayMediator)
        {
            _gamePlayMediator = gamePlayMediator;
        }
        public Character SpawnCharacter()
        {
            Character character = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
            character.onDead += (GameOverType) => _gamePlayMediator.NotifyGameOver(character.GameOverType);
            character.Initialization(_config);
            character.transform.SetParent(_spawnPoint);
            character.transform.localScale = new Vector3(BaseScale, BaseScale, BaseScale);

            return character;
        }


    }
}
