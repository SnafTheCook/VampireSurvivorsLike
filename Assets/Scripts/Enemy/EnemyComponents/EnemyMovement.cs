using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour, IEnemyMoveable
{
    private NavMeshAgent _navAgent;
    private IEnemyData _enemyData;
    public Rigidbody RB { get; set; }

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        _navAgent = GetComponent<NavMeshAgent>();
        _enemyData = GetComponent<IEnemyData>();

        _navAgent.updateRotation = false;
        _navAgent.stoppingDistance = _enemyData.EnemyData.attackRange;
    }

    public void MoveEnemy(Vector3 direction)
    {
        _navAgent.SetDestination(direction);
    }

    public void RotateEnemy(Vector3 direction, float turnSpeed)
    {
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.fixedDeltaTime);
    }
}
