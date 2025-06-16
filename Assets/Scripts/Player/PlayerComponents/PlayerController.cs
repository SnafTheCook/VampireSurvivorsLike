using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IPlayerInput _playerInput;
    private IPlayerMovable _playerMovement;
    private IPlayerAttack _playerAttack;

    private Vector3 _movementDirection = new Vector3(0, 0, 0);

    private void Awake()
    {
        _playerInput = GetComponent<IPlayerInput>();
        _playerMovement = GetComponent<IPlayerMovable>();
        _playerAttack = GetComponent<IPlayerAttack>();
    }

    private void FixedUpdate()
    {
        _movementDirection = _playerMovement.MovePlayer(_movementDirection, _playerInput.GetTargetLookPosition());
    }

    private void ReceiveMovementInput(MovementData movData)
    {
        _movementDirection = movData.direction;
    }

    private void ReceiveAttackInput(int attackId) //TODO: should be deleted if I don't go with any input attacks (not used for now)
    {
        _playerAttack.DoAttack(attackId);
    }

    private void OnEnable()
    {
        _playerInput.OnMovementInput += ReceiveMovementInput;
        _playerInput.OnAttackInput += ReceiveAttackInput;
    }
    private void OnDestroy()
    {
        _playerInput.OnMovementInput -= ReceiveMovementInput;
        _playerInput.OnAttackInput -= ReceiveAttackInput;
    }
}
