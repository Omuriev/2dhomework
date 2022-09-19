using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _path;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 5f;

    private Transform[] _movementPoints;
    private float _direction = 1;
    private float _changeDirectionValue = -1;
    private float _scaleValue = 1;

    private void Awake()
    {
        _movementPoints = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _movementPoints[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(_speed * _direction, _rigidbody2D.velocity.y);
        transform.localScale = new Vector3(_direction, _scaleValue, _scaleValue);
        _animator.SetFloat("Speed", _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<InvisibleWall>(out InvisibleWall invisibleWall))
        {
            _direction *= _changeDirectionValue;
        }
    }
}
