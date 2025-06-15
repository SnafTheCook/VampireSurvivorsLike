using UnityEngine;
using System.Collections.Generic;

public class AttackTriggerChecker : TriggerCheckerBase
{
    private List<Collider> _collidersList = new List<Collider>();

    public List<Collider> GetAttackCollisionsList()
    {
        return _collidersList;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (DoesTagExistInTargetList(coll.gameObject.tag))
            _collidersList.Add(coll);
    }
    private void OnTriggerExit(Collider coll)
    {
        _collidersList.Remove(coll);
    }

    private void OnDestroy()
    {
        _collidersList = new List<Collider>();
    }
}
