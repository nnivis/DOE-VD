using UnityEngine.UI;
using UnityEngine;

namespace VD
{
    public class ViewComponent : MonoBehaviour
    {
        [SerializeField] Image _healthImage;
        public void UpdateHealth(int currentHealth, int maxHealth)
        {
            float healthPercentage = (float)currentHealth / maxHealth * 100f;
            Debug.Log(healthPercentage);
            _healthImage.fillAmount = healthPercentage / 100f;
        }
    }
}
