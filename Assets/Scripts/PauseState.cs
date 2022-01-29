using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : State {

    private InputManager _inputManager;
    private PlayerInventory _playerInventory;
    private GameManager _gameManager;
    private PlayerMovement _playerMovement;
    
    public PauseState(GameManager gameManager) : base(gameManager) {
        _gameManager = ((GameManager) StateMachine);
        _inputManager = _gameManager.inputManager;
        _playerInventory = _gameManager.playerInventory;
        _playerMovement = _gameManager.playerMovement;
    }

    public override void Enter() {
        _playerMovement.canMove = false;
        _inputManager.isGamePaused = true;
    }

    public override void UpdateLogic() {
        if (!_playerInventory.isInventoryOpen) {
            StateMachine.ChangeState(_gameManager.playingState);
        }
    }

    public override void Exit() {
        _playerMovement.canMove = true;
    }
}