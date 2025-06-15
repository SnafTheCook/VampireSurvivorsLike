using UnityEngine;
using UnityEngine.Events;

public class CrateController : MonoBehaviour, IEnemyData
{
    [field: SerializeField] public EnemyDataSO EnemyData { get; set; }

}
