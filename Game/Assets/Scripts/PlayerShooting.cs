using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _projectileStartingPoint;
    [SerializeField] private float _cooldownTime;

    private Collider2D _playerCollider;

    private bool _isShooting = false;
    private bool _canShoot = true;

    void Start()
    {
        _playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (_isShooting && _canShoot)
        {
            Fire();
        }
    }

    private void OnFire(InputValue value)
    {
        _isShooting = value.isPressed;
    }

    private void Fire()
    {
        StartCoroutine(InstantiateProjectile());
    }

    private IEnumerator InstantiateProjectile()
    {
        GameObject instance = Instantiate(_projectile, _projectileStartingPoint.position, Quaternion.identity);

        Collider2D projectileCollider = instance.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(_playerCollider, projectileCollider);
        
        instance.GetComponent<Projectile>().Shoot();

        _canShoot = false;
        yield return new WaitForSeconds(_cooldownTime);
        _canShoot = true;
    }
}
