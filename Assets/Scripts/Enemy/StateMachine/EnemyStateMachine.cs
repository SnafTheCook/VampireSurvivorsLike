using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState CurrentEnemyState { get; set; }

    public void Initialize(EnemyState startingState)
    {
        CurrentEnemyState = startingState;
        CurrentEnemyState.Enter();
    }

    public void ChangeState(EnemyState nextState)
    {
        CurrentEnemyState.Exit();
        CurrentEnemyState = nextState;
        CurrentEnemyState.Enter();
    }
}
