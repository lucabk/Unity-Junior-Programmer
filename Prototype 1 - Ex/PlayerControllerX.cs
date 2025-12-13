using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 10.0f;
    public float rotationSpeed = 18.0f;
    private float verticalInput;
    private Transform propeller;

    private float propellerSpeed = 400.0f;

    void Start()
    {
        propeller = transform.Find("Propeller");
        if (propeller == null) Debug.LogError("Propeller NOT FOUND");
    }

    void FixedUpdate()
    {
        // get the user input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed * verticalInput);

        if (propeller) propeller.Rotate(Vector3.forward * Time.deltaTime * propellerSpeed);
    }
}
