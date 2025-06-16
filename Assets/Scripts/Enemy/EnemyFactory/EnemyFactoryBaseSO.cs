using UnityEngine;

public abstract class EnemyFactoryBaseSO : ScriptableObject
{
    [SerializeField] protected GameObject _enemyPrefab;
    public virtual void CreateEnemy(Vector3 spawnPosition)
    {
        GameObject.Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity); //TODO: implement object pooling
    }
}
