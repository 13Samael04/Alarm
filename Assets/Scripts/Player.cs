using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private Rigidbody _rigidbody;
    private Animator _animator;
    private Vector3 _direction;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _rigidbody.freezeRotation = true;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _direction.x = Input.GetAxis("Horizontal") * _speed;
        _direction.z = Input.GetAxis("Vertical") * _speed;
        _rigidbody.velocity = _direction * _speed;
    }
}
