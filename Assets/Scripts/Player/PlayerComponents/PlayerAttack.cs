using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour, IPlayerAttack //TODO: clean up
{
    [SerializeField] private List<AttackBaseSO> _listOfAllAttacks;
    private event UnityAction OnObjectDestroy;
    private IAnimationController _animationController;

    private void Awake()
    {
        _animationController = GetComponent<IAnimationController>();
    }

    private void OnEnable()
    {
        foreach (var attack in _listOfAllAttacks)
        {
            AttackBaseSO newAttack = Object.Instantiate(attack);
            newAttack.Initialize(transform);
            OnObjectDestroy += newAttack.OnObjectDestroyed;
            newAttack.OnAttack += _animationController.PlayAnimation;
        }
    }
    public void DoAttack(int attackId)
    {
        _listOfAllAttacks[attackId].DoAttack();
    }

    private void OnDestroy()
    {
        OnObjectDestroy?.Invoke();
        OnObjectDestroy = null;
    }

    private void OnDisable()
    {
        OnObjectDestroy?.Invoke();
        OnObjectDestroy = null;
    }

    /*float timer = 1f; //for testing purposes
    private void Update()
    {
        if (timer <= 0)
        {
            timer = 1f;
            DoAttack(0);
        }
        else
            timer -= Time.deltaTime;
    }*/
}

public interface IPlayerAttack
{
    void DoAttack(int attackId);
}