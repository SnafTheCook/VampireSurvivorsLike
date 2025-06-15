using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class ProjectileTriggerChecker : TriggerCheckerBase, ITriggerCheckerEventContainer
{
    public event UnityAction<GameObject> OnTriggerWithTarget = delegate { };
    private void OnTriggerEnter(Collider other)
    {
        if (DoesTagExistInTargetList(other.gameObject.tag))
        {
            OnTriggerWithTarget?.Invoke(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        OnTriggerWithTarget = null;
    }
}

