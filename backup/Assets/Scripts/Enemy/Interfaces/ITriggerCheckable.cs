using UnityEngine;

public interface ITriggerCheckable
{
    bool IsInAttackRange { get; set; }

    void SetIsInAttackRange(bool isInAttackRange);
}
