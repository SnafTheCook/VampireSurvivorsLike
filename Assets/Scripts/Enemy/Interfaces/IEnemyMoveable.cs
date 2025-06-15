using UnityEngine;

public interface IEnemyMoveable
{
    Rigidbody RB { get; set; }

    void MoveEnemy(Vector3 direction);
    void RotateEnemy(Vector3 direction, float turnSpeed);
}
