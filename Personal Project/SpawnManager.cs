using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;

    private static float xSpawn = 21;
    private static float ySpawn = 1;

    private float startDelay = 1;
    private float enemySpawnTime = 1.5f;
    private float powerupSpawnTime = 10;

    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }

    void Update()
    {
    }


    private static Vector3 ReturnRandomPosition()
    {
        return new Vector3(xSpawn, ySpawn, Random.Range(PlayerController.BOTTOM_BORDER, PlayerController.TOP_BORDER));
    }

    private void SpawnRandomEnemy()
    {
        if (!PlayerController.gameOver)
        {
            int randomIndex = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomIndex], ReturnRandomPosition(), enemies[randomIndex].transform.rotation);
        }
    }

    private void SpawnPowerup()
    {
        if (!PlayerController.gameOver)
            Instantiate(powerup, ReturnRandomPosition(), powerup.transform.rotation);
    }
}
