using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent = null;
    [SerializeField] private Animator _animator = null;
    [SerializeField] private List<Transform> _wayPoints = null;
    [SerializeField] private int _currentTarget;
    [SerializeField] private bool _canReverse = false;
    [SerializeField] private bool _targetReached = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        if(_animator == null)
            Debug.Log("Animator is null");
    }

    private void Update()
    {
        if (_wayPoints.Count > 0 && _wayPoints[_currentTarget] != null)
        {
            _agent.SetDestination(_wayPoints[_currentTarget].position);

            float distance = Vector3.Distance(transform.position, _wayPoints[_currentTarget].position);

            if (distance < 1f && (_currentTarget == 0 || _currentTarget == _wayPoints.Count - 1))
            {
                if(_animator != null)
                    _animator.SetBool("isWalking", false);
            }
            else
            {
                if(_animator != null)
                    _animator.SetBool("isWalking", true);
            }
            
            if (distance < 1f && !_targetReached)
            {
                if (_wayPoints.Count < 2) return;
                
                if ((_currentTarget == 0 || _currentTarget == _wayPoints.Count - 1) && _wayPoints.Count > 1)
                {
                    _targetReached = true;
                    StartCoroutine(WaitInWayPointPosRoutine());
                }
                else
                {
                    if (_canReverse)
                    {
                        _currentTarget--;
                        if (_currentTarget <= 0)
                        {
                            _canReverse = false;
                            _currentTarget = 0;
                        }
                    }
                    else
                    {
                        _currentTarget++;
                    }
                }
            }
        }
        else
        {
            _animator.SetBool("isWalking", true);
        }
    }

    private IEnumerator WaitInWayPointPosRoutine()
    {
        float randomSeconds = UnityEngine.Random.Range(2f, 5f);
        
        if (_currentTarget == 0)
        {
            _animator.SetBool("isWalking", false);
            yield return new WaitForSeconds(randomSeconds);
        }
        else if (_currentTarget == _wayPoints.Count - 1)
        {
            _animator.SetBool("isWalking", false);
            yield return new WaitForSeconds(randomSeconds);
        }

        if (_canReverse)
        {
            _currentTarget--;
            
            if (_currentTarget == 0)
            {
                _canReverse = false;
                _currentTarget = 0;
            }
        }
        else if (!_canReverse)
        {
            _currentTarget++;

            if (_currentTarget == _wayPoints.Count)
            {
                _canReverse = true;
                _currentTarget--;
            }
        }

        _targetReached = false;
    }
}
