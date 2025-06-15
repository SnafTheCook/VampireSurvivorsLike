using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/PlayerControlScheme")]
public class PlayerControlsSO : ScriptableObject
{
    public KeyCode upButton = KeyCode.UpArrow;
    public KeyCode downButton = KeyCode.DownArrow;
    public KeyCode leftButton = KeyCode.LeftArrow;
    public KeyCode rightButton = KeyCode.RightArrow;
    public KeyCode attackButton = KeyCode.Space;
}
