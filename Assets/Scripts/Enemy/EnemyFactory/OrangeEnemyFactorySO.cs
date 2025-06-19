using UnityEngine;

[CreateAssetMenu(menuName = "Scriptables/OrangeEnemyFactorySO")]
public class OrangeEnemyFactorySO : EnemyFactoryBaseSO
{
    public override void CreateEnemy(Vector3 spawnPosition, PoolingKeys key)
    {
        ObjectPooling.Instance.CreatePool(PoolingKeys.OrangeEnemy, _enemyPrefab, 10);
        base.CreateEnemy(spawnPosition, key);
    }
}
