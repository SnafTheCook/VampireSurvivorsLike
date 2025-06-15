using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/PlayerBaseData")]
public class PlayerBaseDataSO : ScriptableObject
{
    public float speed = 100;
    public float maxHealth = 100;
    public float turnSpeed = 10;
}
