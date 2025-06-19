using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Scriptables/ProjectileDataSO")]
public class ProjectileDataSO : ScriptableObject
{
    public ProjectileMover projectilePrefab;
    public float projectileSpeed;
    

    public GameObject SpawnProjectile(Transform attackerTransform, List<TargetOfAttacks> possibleTargetsList)
    {
        GameObject projectile = new ProjectileBuilder()
            .WithPrefab(projectilePrefab)
            .WithPoolingKey(PoolingKeys.Fireball)
            .WithSpeed(projectileSpeed)
            .WithTargets(possibleTargetsList)
            .Build(attackerTransform);

        return projectile;
    }
}
