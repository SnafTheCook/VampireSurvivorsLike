using UnityEngine;
using UnityEngine.Events;

public interface ITriggerCheckerEventContainer
{
    public event UnityAction<GameObject> OnTriggerWithTarget;
}
