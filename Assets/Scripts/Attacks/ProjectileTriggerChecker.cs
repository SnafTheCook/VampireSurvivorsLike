using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class ProjectileTriggerChecker : TriggerCheckerBase, ITriggerCheckerEventContainer
{
    public event UnityAction<GameObject> OnTriggerWithTarget = delegate { };
    private void OnTriggerEnter(Collider other)
    {
        if (DoesTagExistInTargetList(other.gameObject))
        {
            OnTriggerWithTarget?.Invoke(other.gameObject);
            ObjectPooling.Instance.GetPool<ProjectileMover>(PoolingKeys.Fireball).ReturnToPool(GetComponent<ProjectileMover>());
        }
    }

    private void OnDisable()
    {
        OnTriggerWithTarget = null;
    }
}

