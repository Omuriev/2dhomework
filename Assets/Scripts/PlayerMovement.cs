using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    const string Speed = "Speed";

    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _jumpForce = 1f;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private float _direction = 1;
    private float _scaleValue = 1;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        MoveHorizontal();
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void MoveHorizontal()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * _speed;

        if (horizontalMovement < 0)
        {
            transform.localScale = new Vector3(-_direction, _scaleValue, _scaleValue);
        }
        else if (horizontalMovement > 0)
        {
            transform.localScale = new Vector3(_direction, _scaleValue, _scaleValue);
        }

        Vector2 movement = new Vector2(horizontalMovement, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = movement;
        _animator.SetFloat(Speed, Mathf.Abs(horizontalMovement));
    }
}
