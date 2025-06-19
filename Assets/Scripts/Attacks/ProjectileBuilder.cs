using System.Collections.Generic;
using UnityEngine;

public class ProjectileBuilder
{
    private ProjectileMover _projectilePrefab;
    private float _speed;
    private List<TargetOfAttacks> _possibleTargetsList;
    private PoolingKeys _poolingKey;

    public ProjectileBuilder WithPrefab(ProjectileMover projectilePrefab)
    {
        _projectilePrefab = projectilePrefab;
        return this;
    }

    public ProjectileBuilder WithPoolingKey(PoolingKeys key)
    {
        _poolingKey = key;
        return this;
    }

    public ProjectileBuilder WithSpeed(float speed)
    {
        _speed = speed;
        return this;
    }

    public ProjectileBuilder WithTargets(List<TargetOfAttacks> possibleTargetsList)
    {
        _possibleTargetsList = possibleTargetsList;
        return this;
    }

    public GameObject Build(Transform attackerTransform)
    {
        ObjectPooling.Instance.CreatePool(_poolingKey, _projectilePrefab, 50);
        var projectile = ObjectPooling.Instance.GetPool<ProjectileMover>(_poolingKey).Get(attackerTransform.position, attackerTransform.rotation);

        projectile.SetSpeed(_speed);
        projectile.GetComponent<ProjectileTriggerChecker>().GetListOfPossibleTargets(_possibleTargetsList);

        return projectile.gameObject;
    }
}
