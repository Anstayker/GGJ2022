using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingState : State {
    
    private InputManager _inputManager;
    private PlayerInventory _playerInventory;
    private GameManager _gameManager;

    public PlayingState(GameManager gameManager) : base(gameManager) {
        _gameManager = ((GameManager) StateMachine);
        _inputManager = _gameManager.inputManager;
        _playerInventory = _gameManager.playerInventory;
    }

    public override void Enter() {
        _inputManager.isGamePaused = false;
    }

    public override void UpdateLogic() {
        if (_playerInventory.isInventoryOpen) {
            StateMachine.ChangeState(_gameManager.pauseState);
        }
    }
}
