using UnityEngine;

namespace VD
{
    public class MoveTowardsCursor
    {
        public void MoveTowards(Transform transform, Camera mainCamera)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
            Vector3 playerPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            transform.position = playerPosition;
        }
    }
}
