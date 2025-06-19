using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/PurpleEnemyFactorySO")]
public class PurpleEnemyFactorySO : EnemyFactoryBaseSO
{
    public override void CreateEnemy(Vector3 spawnPosition, PoolingKeys key)
    {
        ObjectPooling.Instance.CreatePool(PoolingKeys.PurpleEnemy, _enemyPrefab, 10);
        base.CreateEnemy(spawnPosition, key);
    }
}
