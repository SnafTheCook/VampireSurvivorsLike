using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private Queue<T> _pool = new Queue<T>();
    private T _prefab;
    private Transform _parent;

    public ObjectPool(T prefab, int initialSize = 20, Transform parent = null)
    {
        _prefab = prefab;
        _parent = parent;

        for (int i = 0; i < initialSize; i++)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        T newObject = GameObject.Instantiate(_prefab, _parent);
        newObject.gameObject.SetActive(false);
        _pool.Enqueue(newObject);
    }

    public T Get(Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion))
    {
        if (_pool.Count == 0)
        {
            SpawnObject();
        }

        T poolObject = _pool.Dequeue();
        poolObject.gameObject.transform.position = position;
        poolObject.gameObject.transform.rotation = rotation;
        poolObject.gameObject.SetActive(true);

        return poolObject;
    }

    public void ReturnToPool(T poolObject)
    {
        poolObject.gameObject.SetActive(false);
        _pool.Enqueue(poolObject);
    }

}
