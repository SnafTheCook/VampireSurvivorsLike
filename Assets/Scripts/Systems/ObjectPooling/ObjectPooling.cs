using UnityEngine;
using System.Collections.Generic;

public class ObjectPooling : MonoBehaviour
    // making object pool generic at first felt like good idea to reduce amount of code, but after implementing it i feel like
    // it might generate much more code in the long run. might turn T into GameObject in the future
{
    public static ObjectPooling Instance { get; private set; }
    private Dictionary<PoolingKeys, object> _pools = new Dictionary<PoolingKeys, object>();

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);

        Instance = this;
    }

    public void CreatePool<T>(PoolingKeys key, T prefab, int initialSize = 20, Transform parent = null) where T : MonoBehaviour
    {
        if (_pools.ContainsKey(key))
            return;

        _pools[key] = new ObjectPool<T>(prefab, initialSize, parent);
    }

    public ObjectPool<T> GetPool<T>(PoolingKeys key) where T : MonoBehaviour
    {
        return _pools[key] as ObjectPool<T>;
    }
}

public enum PoolingKeys
{
    OrangeEnemy,
    PurpleEnemy,
    Fireball
}
