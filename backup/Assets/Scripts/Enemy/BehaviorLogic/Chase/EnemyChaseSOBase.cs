using UnityEngine;

public class EnemyChaseSOBase : EnemyBehaviorSOBase
{
    public override void DoUpdateFrameLogic() 
    {
        base.DoUpdateFrameLogic();

        if (enemy.IsInAttackRange)
            enemy.StateMachine.ChangeState(enemy.EnemyMeleeAttackState);
    }

}
