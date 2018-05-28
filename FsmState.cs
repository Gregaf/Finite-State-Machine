
abstract public class FsmState<T>
{
    // Called once when changing to this state.
    abstract public void Enter(T owner);

    // Continuously called when this = currentState (Bulk of logic would go here).
    abstract public void Execute(T owner);

    // Called once when changing from this state.
    abstract public void Exit(T owner);
}
