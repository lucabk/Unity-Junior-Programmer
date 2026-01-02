using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 8;
    private int numberOfEnemiesAlive;
    private int waveNumber = 1;
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    void Start()
    {
        SpawnEnemies(waveNumber);
        SpawnPowerup();
    }

    void Update()
    {
        // Trova tutti i gameObject che hanno il componente (script) Enemy
        numberOfEnemiesAlive = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;

        if(numberOfEnemiesAlive == 0) {
            waveNumber++;
            SpawnEnemies(waveNumber);
            SpawnPowerup();
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        return new Vector3(Random.Range(-spawnRange, spawnRange), 0.108f, Random.Range(-spawnRange, spawnRange));
    }

    private void SpawnEnemies(int numberOfEnemies)
    {
        for(int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }
}
