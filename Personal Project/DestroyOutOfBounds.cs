using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float zBound = -30;

    void Start()
    {
    }

    void Update()
    {
        DestroyRocksOutOfBounds();
    }


    private void DestroyRocksOutOfBounds()
    {
        if (transform.position.x < zBound)
        {
            Destroy(gameObject);
        }
    }
}
