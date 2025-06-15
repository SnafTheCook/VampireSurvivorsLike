using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
{
    public float maxHealth = 100;
    public float movementSpeed = 10;
    public float turnSpeed = 10;
    public float damage = 10;
    public float attackRange = 1; //melee
    public float experience = 100;
}
