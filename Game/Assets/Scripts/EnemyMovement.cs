using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private float _stoppingDistance;
    [SerializeField] private float _retreatDistance;
    [SerializeField] private float _spotDistance;
    [SerializeField] private Transform[] _waypoints;

    private Transform _player;

    private int _currentWP = 0;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.queriesStartInColliders = false;
    }

    private void FollowPath()
    {
        if (transform.position == _waypoints[_currentWP].position)
        {
            _currentWP++;
        }

        if (_currentWP >= _waypoints.Length)
        {
            _currentWP = 0;
        }

        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWP].position, _movementSpeed * Time.deltaTime);
    }

    private void FollowPlayer()
    {
        float distance = Vector2.Distance(transform.position, _player.position);
        if (distance > _stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.position, _movementSpeed * Time.deltaTime);
        }
        else if (distance < _retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.position, -_movementSpeed * Time.deltaTime);
        }
    }

    private bool CanSpotPlayer()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, _player.position - transform.position, _spotDistance);
        if (hitInfo.collider == null)
        {
            return false;
        }
        Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        return hitInfo.collider.CompareTag("Player");
    }



    void Update()
    {
        if (CanSpotPlayer())
        {
            FollowPlayer();
        }
        else
        {
            FollowPath();
        }
    }
}
