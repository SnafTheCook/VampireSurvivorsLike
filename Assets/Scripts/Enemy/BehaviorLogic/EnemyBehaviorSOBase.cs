using UnityEngine;

public class EnemyBehaviorSOBase : ScriptableObject
{
    protected EnemyController enemy; //TODO: leaving this as concrete dependency for now as I feel like It will need more refractoring in the future
    protected IEnemyMoveable enemyMovement;
    protected Transform transform;
    protected GameObject gameObject;

    protected Transform playerTransform;

    public virtual void Initialize(GameObject gameObject, EnemyController enemy, IEnemyMoveable enemyMovement)
    {
        this.gameObject = gameObject;
        this.enemy = enemy;
        this.enemyMovement = enemyMovement;
        transform = gameObject.transform;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void DoEnterLogic() { }
    public virtual void DoExitLogic() { }
    public virtual void DoUpdateFrameLogic() { }
    public virtual void DoUpdatePhysicsLogic() { if (playerTransform != null) enemyMovement.RotateEnemy(playerTransform.position - transform.position, enemy.EnemyData.turnSpeed); }
    public virtual void DoAnimationTriggerLogic(EnemyController.AnimationTriggerTypes triggerType) { }
}
