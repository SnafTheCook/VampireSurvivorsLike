using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyFactorySO _enemyFactory;
    private const float ENEMY_SPAWN_DISTANCE = 20f;

    float timer = 0f;
    private void Update() //TODO just spawning every 2s for now
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    public void SpawnEnemy()
    {
        Vector3 spawnPosition = GenerateSpawnPosition();
        int random = Random.Range(0, 2); //TODO just spawning them randomly for now
        if (random == 0)
            _enemyFactory.CreateOrangeEnemy(spawnPosition);
        else
            _enemyFactory.CreatePurpleEnemy(spawnPosition);
    }

    private Vector3 GenerateSpawnPosition()
    {
        Vector2 randomVec = Vector2.zero;
        Vector3 randomSpawnVector = Vector3.zero;

        do
        {
            randomVec = Random.insideUnitCircle.normalized * ENEMY_SPAWN_DISTANCE;
            randomSpawnVector = new Vector3(randomVec.x + transform.position.x, 0, randomVec.y + transform.position.z);
        }
        while (!CheckIfVectorIsInBounds(randomSpawnVector));
        

        return randomSpawnVector;
    }

    private bool CheckIfVectorIsInBounds(Vector3 checkVec)
    {
        if (checkVec.x > FloorCreator.WorldBounds.x || checkVec.x < -FloorCreator.WorldBounds.x ||
            checkVec.z > FloorCreator.WorldBounds.y || checkVec.z < -FloorCreator.WorldBounds.y)
            return false;

        return true;
    }
}
