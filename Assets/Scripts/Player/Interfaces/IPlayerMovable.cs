using UnityEngine;

public interface IPlayerMovable
{
    Vector3 MovePlayer(Vector3 movementDirection, Vector3 targetRotation);
}
