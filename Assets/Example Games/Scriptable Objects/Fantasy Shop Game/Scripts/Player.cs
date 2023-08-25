using UnityEngine;

namespace ExampleGames.ScriptableObjects.FantasyShopGame
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _upperBound;
        [SerializeField]
        private float _lowerBound;
        [SerializeField]
        private float _leftBound;
        [SerializeField]
        private float _rightBound;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            var position = _transform.position;
            if (Input.GetKey(KeyCode.W) && position.y < _upperBound)
            {
                _transform.Translate(Vector3.up * Time.deltaTime * _speed, Space.World);
            }

            if (Input.GetKey(KeyCode.S) && position.y > _lowerBound)
            {
                _transform.Translate(Vector3.down * Time.deltaTime * _speed, Space.World);
            }

            if (Input.GetKey(KeyCode.A) && position.x > _leftBound)
            {
                _transform.Translate(Vector3.left * Time.deltaTime * _speed, Space.World);
            }

            if (Input.GetKey(KeyCode.D) && position.x < _rightBound)
            {
                _transform.Translate(Vector3.right * Time.deltaTime * _speed, Space.World);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("hej");
        }
    }
}


