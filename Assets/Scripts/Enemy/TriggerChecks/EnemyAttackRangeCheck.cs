using UnityEngine;

public class EnemyAttackRangeCheck : MonoBehaviour
{
    [System.NonSerialized] public GameObject playerTarget;
    private EnemyController _enemy;

    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        _enemy = GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == playerTarget)
        {
            _enemy.SetIsInAttackRange(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject == playerTarget)
        {
            _enemy.SetIsInAttackRange(false);
        }
    }
}
