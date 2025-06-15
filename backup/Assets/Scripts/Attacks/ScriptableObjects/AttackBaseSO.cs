using UnityEngine;
using System.Collections.Generic;

public class AttackBaseSO : ScriptableObject
{
    [SerializeField] protected float range = 1f;
    [SerializeField] protected float attacksPerSecond = 1f;
    [SerializeField] protected float baseDamage = 10f;
    [SerializeField] protected List<TargetOfAttacks> possibleTargets;
    protected AttackTriggerChecker _triggerChecker;

    public virtual void DoAttack() { }
    public virtual void Initialize(Transform attackerTransform) { }

    protected GameObject CreateTriggerCheckGameObject(Transform attackerTransform, string GOname)
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
                            coll.gameObject.GetComponent<IDamageable>().Damage(baseDamage);
                    }
                }
            }
        }
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
