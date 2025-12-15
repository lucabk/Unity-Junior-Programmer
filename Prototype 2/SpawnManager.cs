using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void Update()
    {

    }

    private void SpawnRandomAnimal()
    {
        int index = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-PlayerController.xRange, PlayerController.xRange), 0, spawnPosZ);
        Instantiate(animalPrefabs[index], spawnPos, animalPrefabs[index].transform.rotation);
    }
}
