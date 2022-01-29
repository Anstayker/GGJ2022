using System;
using UnityEngine;

public class StateMachine : MonoBehaviour {

    private State _currentState;

    private void Start() {
        _currentState = GetInitialState();
    }

    private void Update() {
        _currentState?.UpdateLogic();
    }

    private void LateUpdate() {
        _currentState?.UpdatePhysics();
    }

    public void ChangeState(State newState) {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    protected virtual State GetInitialState() {
        return null;
    }
    
}