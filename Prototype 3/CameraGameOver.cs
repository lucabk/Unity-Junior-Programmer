using UnityEngine;

public class CameraGameOver : MonoBehaviour
{
    private PlayerController playerControllerScript;
    private bool moved = false;
    private float leftBound = 10;
    private float speed = 10;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerControllerScript.gameOver && !moved)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            if (transform.position.x < leftBound ) moved = true;
        }
    }
}
