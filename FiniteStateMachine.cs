
public class FiniteStateMachine<T>
{
    private T Owner;
    private FsmState<T> CurrentState;
    private FsmState<T> PreviousState;

    // Initialize
    public void Awake()
    {
        CurrentState = null;
        PreviousState = null;
    }

    // 'T' Class will be set to the owner (the class using the FSM).
    // Then change the current state from null to the starting state.
    public void Configure(T owner, FsmState<T> InitialState)
    {
        Owner = owner;
        ChangeState(InitialState);
    }

    // Game loop
    public void Update()
    {
        // If there is a state then Execute will be called allowing for the use of...
        // Update in the State class.
        if (CurrentState != null)
            CurrentState.Execute(Owner);
    }

    public void ChangeState(FsmState<T> NewState)
    {
        // Change the previous state to the current state for more functionality.
        PreviousState = CurrentState;

        if (CurrentState != null)
            CurrentState.Exit(Owner);

        // Set the current state to new state
        CurrentState = NewState;
    
        if (CurrentState != null)
            CurrentState.Enter(Owner);
    }

    public void RevertToPreviousState()
    {
        if (PreviousState != null)
            ChangeState(PreviousState);
    }
};
