using UnityEngine;

public class MoveForwardX : MonoBehaviour
{
    public float speed;

    // Move the dog forward
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
