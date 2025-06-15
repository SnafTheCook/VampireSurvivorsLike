using UnityEngine;
using Unity.AI.Navigation;

public class FloorCreator : MonoBehaviour
{
    [SerializeField] private FloorSetSO _floorSet;
    private NavMeshSurface _navMeshSurface;
    public static Vector2 WorldBounds;

    private void Awake()
    {
        _floorSet.SpawnTiles(transform);
        _floorSet.CalculateWorldBounds();
        _navMeshSurface = GetComponent<NavMeshSurface>();
        _navMeshSurface.BuildNavMesh();
    }
}


