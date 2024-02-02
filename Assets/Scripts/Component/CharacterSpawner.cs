using UnityEngine;

namespace VD
{
    public class CharacterSpawner : MonoBehaviour
    {

        [SerializeField] private CharacterConfig _config;
        [SerializeField] private Character _prefab;
        [SerializeField] private Transform _spawnPoint;

        public void StartWork()
        {
            SpawnCharacter();
        }
        private void SpawnCharacter()
        {
            Character character = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
            character.Initialization(_config);
            character.transform.SetParent(_spawnPoint);
            character.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        }


    }
}
