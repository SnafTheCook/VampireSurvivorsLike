using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/RangedProjectileAttackSO")]
public class RangedProjectileAttackSO : AttackBaseSO
{
    [SerializeField] private ProjectileDataSO projectileData;

    public override void Initialize(Transform attackerTransform)
    {
        base.Initialize(attackerTransform);
    }
    public override void DoAttack()
    {
        base.DoAttack();
        ITriggerCheckerEventContainer triggerCheckerEvent = projectileData.SpawnProjectile(attackerTransform, possibleTargets).GetComponent<ITriggerCheckerEventContainer>();
        triggerCheckerEvent.OnTriggerWithTarget += TryDealDamage;
    }

    
}
