using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private Rigidbody _rigidbody;
    private Vector3 _direction;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        const string Horizontal = nameof(Horizontal);
        const string Vertical = nameof(Vertical);

        _direction.x = Input.GetAxis(Horizontal) * _speed;
        _direction.z = Input.GetAxis(Vertical) * _speed;
        _rigidbody.velocity = _direction * _speed;
    }
}
