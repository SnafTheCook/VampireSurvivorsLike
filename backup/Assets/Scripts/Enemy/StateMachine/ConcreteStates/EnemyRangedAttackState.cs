using UnityEngine;

public class EnemyRangedAttackState : EnemyState
{
    public EnemyRangedAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTrigger(Enemy.AnimationTriggerTypes triggerType)
    {
        base.AnimationTrigger(triggerType);
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
