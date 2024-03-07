using UnityEngine;
using UnityEngine.UI;

namespace VD
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] Button _inactiveButton;
        [SerializeField] Button _activeButton;
        [SerializeField] Button _passedButton;

        public void InactiveState()
        {
            _inactiveButton.gameObject.SetActive(true);
            _activeButton.gameObject.SetActive(false);
            _passedButton.gameObject.SetActive(false);
        }

        public void ActiveState()
        {
            _inactiveButton.gameObject.SetActive(false);
            _activeButton.gameObject.SetActive(true);
            _passedButton.gameObject.SetActive(false);
        }

        public void PassedState()
        {
            _inactiveButton.gameObject.SetActive(false);
            _activeButton.gameObject.SetActive(false);
            _passedButton.gameObject.SetActive(true);
        }
    }
}
