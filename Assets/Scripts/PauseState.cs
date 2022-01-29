using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : State {

    private InputManager _inputManager;
    private PlayerInventory _playerInventory;
    GameManager _gameManager;
    
    public PauseState(GameManager gameManager) : base(gameManager) {
        _gameManager = ((GameManager) StateMachine);
        _inputManager = _gameManager.inputManager;
        _playerInventory = _gameManager.playerInventory;
    }

    public override void Enter() {
        _inputManager.isGamePaused = true;
    }

    public override void UpdateLogic() {
        if (!_playerInventory.isInventoryOpen) {
            StateMachine.ChangeState(_gameManager.playingState);
        }
    }
}