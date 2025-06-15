using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerMovable
{
    [SerializeField] private PlayerBaseDataSO _playerData;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public Vector3 MovePlayer(Vector3 movementDirection)
    {

        if (movementDirection != new Vector3(0, 0, 0))
        {
            _rb.linearVelocity = movementDirection * _playerData.speed * Time.fixedDeltaTime;
            Quaternion rotation = Quaternion.LookRotation(movementDirection);
            _rb.MoveRotation(Quaternion.Slerp(transform.rotation, rotation, _playerData.turnSpeed * Time.fixedDeltaTime));
        }
        return new Vector3(0, 0, 0);

    }
}
