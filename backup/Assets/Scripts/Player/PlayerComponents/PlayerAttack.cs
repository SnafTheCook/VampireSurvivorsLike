using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IPlayerAttack
{
    [SerializeField] private List<AttackBaseSO> _listOfAllAttacks;

    private void Awake()
    {
        foreach (var attack in _listOfAllAttacks)
        {
            attack.Initialize(transform);
        }
    }
    public void DoAttack(int attackId)
    {
        _listOfAllAttacks[attackId].DoAttack();
    }

    float timer = 1f;
    private void Update()
    {
        if (timer <= 0)
        {
            timer = 1f;
            DoAttack(0);
        }
        else
            timer -= Time.deltaTime;
    }
}

public interface IPlayerAttack
{
    void DoAttack(int attackId);
}