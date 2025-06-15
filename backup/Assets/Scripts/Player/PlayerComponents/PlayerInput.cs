using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour, IPlayerInput
{
    [SerializeField] private PlayerControlsSO _controlScheme;

    public event UnityAction<MovementData> OnMovementInput;
    public event UnityAction<int> OnAttackInput;

    private void OnEnable()
    {
        if (_controlScheme == null)
        {
            _controlScheme = new PlayerControlsSO();
        }
    }

    void Update()
    {
        Vector3 direction = new Vector3(0, 0, 0);

        if (Input.GetKey(_controlScheme.upButton))
            direction += new Vector3(0, 0, 1);
        if (Input.GetKey(_controlScheme.downButton))
            direction += new Vector3(0, 0, -1);
        if (Input.GetKey(_controlScheme.leftButton))
            direction += new Vector3(-1, 0, 0);
        if (Input.GetKey(_controlScheme.rightButton))
            direction += new Vector3(1, 0, 0);

        if (direction != new Vector3(0, 0, 0))
            OnMovementInput?.Invoke(new MovementData(direction.normalized, true));


        if (Input.GetKey(_controlScheme.attackButton))
            OnAttackInput?.Invoke(0);
    }
}
