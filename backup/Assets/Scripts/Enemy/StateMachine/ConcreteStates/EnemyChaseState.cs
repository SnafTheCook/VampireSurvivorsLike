using UnityEngine;

public class EnemyChaseState : EnemyState
{
    
    public EnemyChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTrigger(Enemy.AnimationTriggerTypes triggerType)
    {
        base.AnimationTrigger(triggerType);
        enemy.EnemyChaseBaseInstance.DoAnimationTriggerLogic(triggerType);
    }

    public override void Enter()
    {
        base.Enter();
        enemy.EnemyChaseBaseInstance.DoEnterLogic();
    }

    public override void Exit()
    {
        base.Exit();
        enemy.EnemyChaseBaseInstance.DoExitLogic();
    }

    public override void UpdateFrame()
    {
        base.UpdateFrame();
        enemy.EnemyChaseBaseInstance.DoUpdateFrameLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        enemy.EnemyChaseBaseInstance.DoUpdatePhysicsLogic();
    }
}
