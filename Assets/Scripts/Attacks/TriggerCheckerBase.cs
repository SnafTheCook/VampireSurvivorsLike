using System.Collections.Generic;
using UnityEngine;

public class TriggerCheckerBase : MonoBehaviour
{
    protected List<string> _possibleTargetsTags = new List<string>();

    private void OnEnable()
    {
        _possibleTargetsTags = new List<string>();
    }

    public void GetListOfPossibleTargets(List<TargetOfAttacks> targetsList)
    {
        foreach (var tag in targetsList)
        {
            _possibleTargetsTags.Add(tag.ToString());
        }
    }

    protected bool DoesTagExistInTargetList(GameObject taggedObject)
    {
        foreach (var tag in _possibleTargetsTags)
        {
            if (taggedObject.CompareTag(tag))
                return true;
        }
        return false;
    }
}
