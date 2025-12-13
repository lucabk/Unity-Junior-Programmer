using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private float speed = 20.0f; 
    private float turnSpeed = 18.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player inputs
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        
        // Move the vehicle forward (20 m/s toward Z axis) 
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput); 
        // Rotate the veichle (Y axis)
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput); 
    }
}
