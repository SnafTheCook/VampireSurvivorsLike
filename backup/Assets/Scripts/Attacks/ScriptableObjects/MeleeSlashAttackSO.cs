using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/MeleeSlashAttackSO")]
public class MeleeSlashAttackSO : AttackBaseSO
{
    
    public override void Initialize(Transform attackerTransform)
    {
        base.Initialize(attackerTransform);

        GameObject rangeCheckGameObject = CreateTriggerCheckGameObject(attackerTransform, "MeleeSlashAttackRangeChecker");
        AddCollider(rangeCheckGameObject);
        InitializeTriggerChecker(rangeCheckGameObject);
    }

    public override void DoAttack()
    {
        base.DoAttack();
        CheckForCollisionsAndDamage();
    }
}
