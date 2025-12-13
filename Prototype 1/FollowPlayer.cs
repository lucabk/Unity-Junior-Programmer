using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 cameraOffset = new Vector3(0, 10, -9);

    void Start()
    {
        
    }

    // Si usa LateUpdate perché così si aggiorna prima il movimento del veicolo e poi la camera (no stuttering)
    void LateUpdate()
    {
        transform.position = player.transform.position + cameraOffset; // si mette la posizione della camera alla stessa del veicolo più un offset
    }
}
