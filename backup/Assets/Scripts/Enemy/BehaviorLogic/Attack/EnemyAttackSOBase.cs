using UnityEngine;

public class EnemyAttackSOBase : EnemyBehaviorSOBase
{
    public override void DoUpdateFrameLogic()
    {
        base.DoUpdateFrameLogic();

        if (!enemy.IsInAttackRange)
            enemy.StateMachine.ChangeState(enemy.EnemyChaseState);
    }

}
