using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class AttackBaseSO : ScriptableObject, ITimerable
{
    [SerializeField] protected float range = 1f;
    [SerializeField] protected float attacksPerSecond = 1f;
    [SerializeField] protected float baseDamage = 10f;
    [SerializeField] protected List<TargetOfAttacks> possibleTargets;
    protected AttackTriggerChecker _triggerChecker;
    protected Transform attackerTransform;
    private TimerItem _timerHandle;
    public event UnityAction OnAttack = delegate { };
    public virtual void DoAttack() 
    {
        OnAttack?.Invoke();
    }
    public virtual void Initialize(Transform attackerTransform)
    {
        this.attackerTransform = attackerTransform;
        _timerHandle = TimerSystem.Instance.Subscribe(this, attacksPerSecond);
    }

    public void OnObjectDestroyed()
    {
        TimerSystem.Instance.Unsubscribe(_timerHandle);
        OnAttack = null;
    }

    public void Execute()
    {
        DoAttack();
    }

    protected GameObject CreateTriggerCheckGameObject(string GOname) //TODO just make it a builder
    {
        GameObject rangeCheckGameObject = new GameObject(GOname);
        rangeCheckGameObject.transform.parent = attackerTransform;
        rangeCheckGameObject.transform.localPosition = new Vector3(0, 0, range);
        return rangeCheckGameObject;
    }
    protected Collider AddCollider(GameObject rangeCheckGameObject)
    {
        SphereCollider collider = rangeCheckGameObject.AddComponent<SphereCollider>();
        collider.isTrigger = true;
        collider.radius = range;
        return collider;
    }
    protected void InitializeTriggerChecker(GameObject rangeCheckGameObject)
    {
        _triggerChecker = rangeCheckGameObject.AddComponent<AttackTriggerChecker>();
        _triggerChecker.GetListOfPossibleTargets(possibleTargets);
    }

    protected void CheckForCollisionsAndDamage()
    {
        List<Collider> collisions = _triggerChecker.GetAttackCollisionsList();
        if (collisions != null)
        {
            foreach (var coll in collisions)
            {
                foreach (var tag in possibleTargets)
                {
                    if (coll != null)
                    {
                        if (tag.ToString() == coll.gameObject.tag)
                            TryDealDamage(coll.gameObject);
                    }
                }
            }
        }
    }

    protected void TryDealDamage(GameObject target)
    {
        target.GetComponent<IDamageable>()?.Damage(baseDamage);
    }
}

[System.Serializable]
public enum TargetOfAttacks
{
    Player,
    Enemy,
    Crate,
    Door,
}
