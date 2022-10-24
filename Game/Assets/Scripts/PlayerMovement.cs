using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private float _jumpSpeed = 10f;

    private Rigidbody2D _rigidbody;
    private Collider2D _feetCollider;

    private Vector2 _movementVec;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _feetCollider = GetComponentInChildren<Collider2D>();
    }

    private void OnMove(InputValue value)
    {
        _movementVec = value.Get<Vector2>();
    }

    private void HandleMove()
    {
        transform.Translate(new Vector3(_movementVec.x * _movementSpeed * Time.deltaTime, 0f, 0f));
    }

    private void OnJump(InputValue value)
    {
        Debug.Log("jump");
        if (!_feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (value.isPressed)
        {
            _rigidbody.velocity += new Vector2(0f, _jumpSpeed);
        }
    }

    void Update()
    {
        HandleMove();
    }
}
