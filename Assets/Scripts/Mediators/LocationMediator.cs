using UnityEngine;

namespace VD
{
    public class LocationMediator : MonoBehaviour
    {
        [SerializeField] private LocationHandler _locationHandler;

        public void ActiveLevel(int levelIndex)
        {
            _locationHandler.ActiveLevel(levelIndex);
        }
    }
}
