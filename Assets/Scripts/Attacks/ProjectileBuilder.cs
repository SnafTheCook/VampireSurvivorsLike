using System.Collections.Generic;
using UnityEngine;

public class ProjectileBuilder
{
    private GameObject _projectilePrefab;
    private float _speed;
    private List<TargetOfAttacks> _possibleTargetsList;

    public ProjectileBuilder WithPrefab(GameObject projectilePrefab)
    {
        _projectilePrefab = projectilePrefab;
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
        GameObject projectile = GameObject.Instantiate(_projectilePrefab, attackerTransform.position, attackerTransform.rotation);
        projectile.GetComponent<ProjectileMover>().SetSpeed(_speed);
        projectile.GetComponent<ProjectileTriggerChecker>().GetListOfPossibleTargets(_possibleTargetsList);

        return projectile;
    }
}
