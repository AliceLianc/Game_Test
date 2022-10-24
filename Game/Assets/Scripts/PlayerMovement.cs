using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private Vector2 movementVec;

    private void OnMove(InputValue value)
    {
        movementVec = value.Get<Vector2>();
    }

    private void HandleMove()
    {
        
        transform.Translate(new Vector3(movementVec.x * _speed * Time.deltaTime, 0f, 0f));
    }

    void Update()
    {
        HandleMove();
    }
}
