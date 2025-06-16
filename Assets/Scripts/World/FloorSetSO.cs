using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Scriptables/FloorSetSO")]
public class FloorSetSO : ScriptableObject
{
    [SerializeField] private List<GameObject> _floorTilesPrefabs;
    [SerializeField] private FloorSetData _floorSetData;

    public void SpawnTiles(Transform transform)
    {
        //calculate position depending on if the number of tiles is an even number or not 
        float xPos = _floorSetData.tileWidth * (_floorSetData.numberOfTilesHorizontally - (_floorSetData.numberOfTilesHorizontally % 2 == 0 ? 1 : 0)) / 2;
        float yPos = _floorSetData.tileWidth * (_floorSetData.numberOfTilesVertically - (_floorSetData.numberOfTilesVertically % 2 == 0 ? 1 : 0)) / 2;

        Vector3 startingPosition = new Vector3(xPos, -1, yPos);
        Vector3 spawnPosition = startingPosition;

        for (int i = 0; i < _floorSetData.numberOfTilesHorizontally; i++)
        {
            for (int j = 0; j < _floorSetData.numberOfTilesVertically; j++)
            {
                int random = Random.Range(0, _floorTilesPrefabs.Count);
                GameObject tile = Instantiate(_floorTilesPrefabs[random], spawnPosition, Quaternion.identity);
                tile.transform.parent = transform;
                spawnPosition = new Vector3(spawnPosition.x, -1, spawnPosition.z - _floorSetData.tileHeight);
            }
            spawnPosition = new Vector3(spawnPosition.x - _floorSetData.tileWidth, -1, startingPosition.z);
        }
    }

    public void CalculateWorldBounds()
    {
        FloorCreator.WorldBounds = new Vector2
            (_floorSetData.tileWidth * (_floorSetData.numberOfTilesHorizontally) / 2, 
            _floorSetData.tileHeight * (_floorSetData.numberOfTilesVertically) / 2);
    }

}
[System.Serializable]
public struct FloorSetData
{
    public float tileWidth;
    public float tileHeight;
    public int numberOfTilesHorizontally;
    public int numberOfTilesVertically;
}
