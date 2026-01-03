using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 10;

    void Start()
    {
        
    }

    void Update()
    {
        if (!PlayerController.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        } else
        {
            Destroy(gameObject);
        }       
    }
}
