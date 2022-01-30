using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    private Transform _target;
    private NavMeshAgent _agent;
    private Vector3 _previousVelocity;
    
    [HideInInspector] public bool isGamePaused = false;

    private void Start() {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _target = FindObjectOfType<PlayerMovement>().transform;

    }

    private void Update() {
        if (isGamePaused) {
            PauseMovement();
        }
        else {
            _agent.SetDestination(_target.position);
        }
    }

    private void PauseMovement() {
        _previousVelocity = _agent.velocity;
        _agent.velocity = Vector3.zero;
    }

    public void UnPauseMovement() {
        _agent.velocity = _previousVelocity;
    }
    
}
