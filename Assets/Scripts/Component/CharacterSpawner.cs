using UnityEngine;

namespace VD
{
    public class CharacterSpawner : MonoBehaviour
    {

        [SerializeField] private CharacterConfig _config;
        [SerializeField] private Character _prefab;
        [SerializeField] private Transform _spawnPoint;
         private const float  BaseScale = 3.0f;

        public  Character SpawnCharacter()
        {
            Character character = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity);
            character.Initialization(_config);
            character.transform.SetParent(_spawnPoint);
            character.transform.localScale = new Vector3(BaseScale, BaseScale, BaseScale);

            return character;
        }


    }
}
