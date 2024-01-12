using UnityEngine;

namespace VD
{
    public class InteractTestComponent : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other);
        }
        
    }
}
