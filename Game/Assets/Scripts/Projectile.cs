using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Rigidbody2D _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    public void Shoot()
    {
        _rigidbody.velocity = new Vector2(_speed, 0f);
    }
}
