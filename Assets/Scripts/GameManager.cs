using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : StateMachine {

    [HideInInspector] public PlayingState playingState;
    [HideInInspector] public PauseState pauseState;
    
    public PlayerMovement player;
    [HideInInspector] public InputManager inputManager;
    [HideInInspector] public PlayerInventory playerInventory;
    
    private void Awake() {
        inputManager = player.GetComponent<InputManager>();
        playerInventory = player.GetComponent<PlayerInventory>();
        
        playingState = new PlayingState(this);
        pauseState = new PauseState(this);
    }

    protected override State GetInitialState() {
        return playingState;
    }
    
}