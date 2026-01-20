using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float speed = 50;

    void Start()
    {
        
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, Time.deltaTime * speed * horizontalInput);
    }
}
