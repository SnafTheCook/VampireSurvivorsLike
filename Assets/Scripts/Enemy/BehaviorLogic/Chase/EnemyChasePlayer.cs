using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/EnemyChasePlayer")]
public class EnemyChasePlayer : EnemyChaseSOBase
{
    public override void DoUpdateFrameLogic()
    {
        base.DoUpdateFrameLogic();

        if (playerTransform != null)
            enemyMovement.MoveEnemy(playerTransform.position);
    }
}
