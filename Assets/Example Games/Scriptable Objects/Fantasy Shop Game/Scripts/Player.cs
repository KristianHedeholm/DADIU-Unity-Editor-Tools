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
        private bool _isInsideShop = false;
        private ItemShop _currentVisitingShop;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            var position = _transform.position;
            if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow) && position.y < _upperBound))
            {
                _transform.Translate(Vector3.up * Time.deltaTime * _speed, Space.World);
            }

            if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow) && position.y > _lowerBound))
            {
                _transform.Translate(Vector3.down * Time.deltaTime * _speed, Space.World);
            }

            if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow) && position.x > _leftBound))
            {
                _transform.Translate(Vector3.left * Time.deltaTime * _speed, Space.World);
            }

            if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow) && position.x < _rightBound))
            {
                _transform.Translate(Vector3.right * Time.deltaTime * _speed, Space.World);
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(_isInsideShop)
                {
                    _currentVisitingShop.ShowShop();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {;
            if(collider.TryGetComponent<ItemShop>(out var itemShop))
            {
                _isInsideShop = true;
                _currentVisitingShop = itemShop;
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.TryGetComponent<ItemShop>(out var itemShop))
            {
                _isInsideShop = false;
            }
        }
    }
}


