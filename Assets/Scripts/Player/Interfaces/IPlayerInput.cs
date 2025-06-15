using UnityEngine;
using UnityEngine.Events;

public interface IPlayerInput
{
    public event UnityAction<MovementData> OnMovementInput;
    public event UnityAction<int> OnAttackInput;
    public Vector3 GetTargetLookPosition();
}

public struct MovementData
{
    public Vector3 direction;
    public bool someCondition;

    public MovementData(Vector3 direction, bool someCondition)
    {
        this.direction = direction;
        this.someCondition = someCondition;
    }
}
