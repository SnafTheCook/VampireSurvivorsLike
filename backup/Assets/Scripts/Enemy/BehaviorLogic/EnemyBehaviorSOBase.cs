using UnityEngine;

public class EnemyBehaviorSOBase : ScriptableObject
{
    protected Enemy enemy;
    protected Transform transform;
    protected GameObject gameObject;

    protected Transform playerTransform;

    public virtual void Initialize(GameObject gameObject, Enemy enemy)
    {
        this.gameObject = gameObject;
        this.enemy = enemy;
        transform = gameObject.transform;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public virtual void DoEnterLogic() { }
    public virtual void DoExitLogic() { }
    public virtual void DoUpdateFrameLogic() { }
    public virtual void DoUpdatePhysicsLogic() { if (playerTransform != null) enemy.RotateEnemy(playerTransform.position - transform.position); }
    public virtual void DoAnimationTriggerLogic(Enemy.AnimationTriggerTypes triggerType) { }
}
