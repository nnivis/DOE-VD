using UnityEngine;

namespace VD
{

    public class DiceMove : MonoBehaviour
    {
        private Rigidbody2D _rigidBody2D;

        private float baseSpeed = 3f;
        private float maxSpeed = Mathf.Infinity;
        public float currentSpeed { get;set; }

        public void Initialize(Rigidbody2D rigidbody2D)
        {
            _rigidBody2D = rigidbody2D;
        }

        public void AddStartingForce()
        {
            float x = Random.value < 0.5f ? -1f : 1f;
            float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f) : Random.Range(0.5f, 1f);

            Vector2 direction = new Vector2(x, y).normalized;
            _rigidBody2D.AddForce(direction * baseSpeed, ForceMode2D.Impulse);
            currentSpeed = baseSpeed;
        }

        public void ResetPosition()
        {
            _rigidBody2D.velocity = Vector2.zero;
            _rigidBody2D.position = Vector2.zero;
        }

        public void UpdateMovement()
        {
            Vector2 direction = _rigidBody2D.velocity.normalized;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
            _rigidBody2D.velocity = direction * currentSpeed;
        }
    }
}

