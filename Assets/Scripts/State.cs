public abstract class State {

    protected StateMachine StateMachine;

    protected State(StateMachine stateMachine) {
        StateMachine = stateMachine;
    }
    
    public virtual void Enter() { }
    
    public virtual void UpdateLogic() { }
    
    public virtual void UpdatePhysics() { }
    
    public virtual void Exit() { }
    
}