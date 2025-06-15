using UnityEngine;

public class EnemyState
{
    protected Enemy enemy;
    protected EnemyStateMachine enemyStateMachine;

    public EnemyState(Enemy enemy, EnemyStateMachine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
    }


    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void UpdateFrame() { }
    public virtual void UpdatePhysics() { }
    public virtual void AnimationTrigger(Enemy.AnimationTriggerTypes triggerType) { }
}
