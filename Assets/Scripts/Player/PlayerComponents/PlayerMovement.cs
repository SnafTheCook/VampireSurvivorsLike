using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerMovable
{
    [SerializeField] private PlayerBaseDataSO _playerData;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public Vector3 MovePlayer(Vector3 movementDirection, Vector3 targetRotation)
    {
        if (movementDirection != new Vector3(0, 0, 0))
            PlayerSetVelocity(movementDirection);
        RotatePlayer(targetRotation);

        return new Vector3(0, 0, 0);
    }

    private void PlayerSetVelocity(Vector3 movementDirection)
    {
        _rb.linearVelocity = movementDirection * _playerData.speed * Time.fixedDeltaTime;
    }

    private void RotatePlayer(Vector3 targetRotation)
    {
        if (targetRotation != new Vector3(0, 0, 0))
        {
            Quaternion rotation = Quaternion.LookRotation(targetRotation);
            _rb.MoveRotation(Quaternion.Slerp(transform.rotation, rotation, _playerData.turnSpeed * Time.fixedDeltaTime));
        }
    }
}
