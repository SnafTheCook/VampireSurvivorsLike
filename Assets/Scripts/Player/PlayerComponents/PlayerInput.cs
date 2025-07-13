using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, IPlayerInput
{
    [SerializeField] private PlayerControlsSO _controlScheme;
    [SerializeField] private LayerMask _rayFloorLayer;

    public event UnityAction<MovementData> OnMovementInput;
    public event UnityAction<int> OnAttackInput;
    private Vector3 _movementDirection = new Vector3(0, 0, 0);
    private Vector3 _mousePosition = new Vector3(0, 0, 0);

    private void OnEnable()
    {
        if (_controlScheme == null)
        {
            _controlScheme = new PlayerControlsSO();
        }
    }

    void Update()
    {
        if (_movementDirection != new Vector3(0, 0, 0))
            OnMovementInput?.Invoke(new MovementData(_movementDirection.normalized, true));


        if (Input.GetKey(_controlScheme.attackButton))
            OnAttackInput?.Invoke(0);
    }

    public Vector3 GetTargetLookPosition()
    {
        return _mousePosition;
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        _movementDirection = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
    }
    public void LookInput(InputAction.CallbackContext context)
    {
        Vector3 viewportPosition = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
        Vector3 viewResolutionHalved = new Vector3(Screen.width / 2, 0 ,Screen.height / 2 ); //mouse position starts if left, bottom corner in the new input system
        _mousePosition = (viewportPosition - viewResolutionHalved).normalized;
    }
}
