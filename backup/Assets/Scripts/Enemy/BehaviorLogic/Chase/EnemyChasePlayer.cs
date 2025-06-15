using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/EnemyChasePlayer")]
public class EnemyChasePlayer : EnemyChaseSOBase
{
    public override void DoUpdateFrameLogic()
    {
        base.DoUpdateFrameLogic();

        if (playerTransform != null)
            enemy.MoveEnemy(playerTransform.position);
    }
}
