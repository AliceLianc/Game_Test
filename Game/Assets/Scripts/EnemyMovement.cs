using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 10f;
    [SerializeField] private Transform[] _waypoints;

    private int _currentWP = 0;

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

    void Update()
    {
        FollowPath();
    }
}
