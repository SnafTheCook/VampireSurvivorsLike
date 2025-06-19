using UnityEngine;

public abstract class EnemyFactoryBaseSO : ScriptableObject
{
    [SerializeField] protected EnemyController _enemyPrefab;
    public virtual void CreateEnemy(Vector3 spawnPosition, PoolingKeys key)
    {
        ObjectPooling.Instance.GetPool<EnemyController>(key).Get(spawnPosition);
    }
}
