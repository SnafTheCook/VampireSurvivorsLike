using UnityEngine;

public class EnemyMeleeAttackState : EnemyState
{
    public EnemyMeleeAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTrigger(Enemy.AnimationTriggerTypes triggerType)
    {
        base.AnimationTrigger(triggerType);
        enemy.EnemyAttakBaseInstance.DoAnimationTriggerLogic(triggerType);
    }

    public override void Enter()
    {
        base.Enter();
        enemy.EnemyAttakBaseInstance.DoEnterLogic();
    }

    public override void Exit()
    {
        base.Exit();
        enemy.EnemyAttakBaseInstance.DoExitLogic();
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();
        enemy.EnemyAttakBaseInstance.DoUpdateFrameLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        enemy.EnemyAttakBaseInstance.DoUpdatePhysicsLogic();
    }
}