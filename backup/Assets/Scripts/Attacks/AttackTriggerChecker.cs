using UnityEngine;
using System.Collections.Generic;

public class AttackTriggerChecker : MonoBehaviour
{
    private List<Collider> _collidersList = new List<Collider>();
    private List<string> _possibleTargetsTags = new List<string>();

    public void GetListOfPossibleTargets(List<TargetOfAttacks> targetsList)
    {
        foreach (var tag in targetsList)
        {
            _possibleTargetsTags.Add(tag.ToString());
        }
    }
    public List<Collider> GetAttackCollisionsList()
    {
        CheckForDestroyedColliders();
        return _collidersList;
    }

    private void CheckForDestroyedColliders()
    {
        foreach (var item in _collidersList)
        {
            if (item == null)
                _collidersList.Remove(item);
        }
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

    private bool DoesTagExistInTargetList(string str)
    {
        foreach (var item in _possibleTargetsTags)
        {
            if (str == item)
                return true;
        }
        return false;
    }
}
