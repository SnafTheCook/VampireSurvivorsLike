using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/EnemyFactorySO")]
public class EnemyFactorySO : ScriptableObject
{
    [SerializeField] private OrangeEnemyFactorySO _orangeEnemyFactory;
    [SerializeField] private PurpleEnemyFactorySO _purpleEnemyFactory;

    public void CreateOrangeEnemy(Vector3 spawnPosition)
    {
        _orangeEnemyFactory.CreateEnemy(spawnPosition);
    }

    public void CreatePurpleEnemy(Vector3 spawnPosition)
    {
        _purpleEnemyFactory.CreateEnemy(spawnPosition);
    }
}
