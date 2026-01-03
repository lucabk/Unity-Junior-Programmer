using UnityEngine;

public class CentreCamera : MonoBehaviour
{
    private float cameraOffset = 12;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }


    void LateUpdate()
    {
        if (transform.position.x > player.transform.position.x + cameraOffset)
        {
            transform.position = new Vector3(
                player.transform.position.x + cameraOffset, 
                transform.position.y, 
                transform.position.z
            );
        }
    }
}
