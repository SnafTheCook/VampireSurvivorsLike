using System.Collections.Generic;
using UnityEngine;

public class TriggerCheckerBase : MonoBehaviour
{
    protected List<string> _possibleTargetsTags = new List<string>();

    public void GetListOfPossibleTargets(List<TargetOfAttacks> targetsList)
    {
        foreach (var tag in targetsList)
        {
            _possibleTargetsTags.Add(tag.ToString());
        }
    }

    protected bool DoesTagExistInTargetList(string str)
    {
        foreach (var item in _possibleTargetsTags)
        {
            if (str == item)
                return true;
        }
        return false;
    }
}
