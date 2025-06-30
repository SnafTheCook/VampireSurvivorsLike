using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour, IPlayerInput //super simple input for now //TODO: implement InputSystem
{
    private static Camera mainCam;
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
        if (mainCam == null)
            mainCam = Camera.main;
    }

    void Update()
    {
        /*if (Input.GetKey(_controlScheme.upButton))
            direction += new Vector3(0, 0, 1);
        if (Input.GetKey(_controlScheme.downButton))
            direction += new Vector3(0, 0, -1);
        if (Input.GetKey(_controlScheme.leftButton))
            direction += new Vector3(-1, 0, 0);
        if (Input.GetKey(_controlScheme.rightButton))
            direction += new Vector3(1, 0, 0);*/

        if (_movementDirection != new Vector3(0, 0, 0))
            OnMovementInput?.Invoke(new MovementData(_movementDirection.normalized, true));


        if (Input.GetKey(_controlScheme.attackButton))
            OnAttackInput?.Invoke(0);


    }

    public Vector3 GetTargetLookPosition()
    {
        /*if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out RaycastHit raycast, Mathf.Infinity, _rayFloorLayer.value, QueryTriggerInteraction.Ignore))
        {
            Vector3 returnVector = new Vector3(raycast.point.x - transform.position.x, 0, raycast.point.z - transform.position.z);
            return returnVector;
        }
        else
            return new Vector3(0, 0, 0);*/

        return _mousePosition;
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        _movementDirection = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
    }
    public void LookInput(InputAction.CallbackContext context) //TODO: mouse delta doesnt feel natural, probably should find a way to switch between raycasts for mouse and delta for gamepads
    {
        Vector3 viewportPosition = new Vector3(context.ReadValue<Vector2>().x, 0, context.ReadValue<Vector2>().y);
        _mousePosition = viewportPosition.normalized;
    }
}
