using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
      Destroy(other.gameObject);
      Destroy(gameObject);
    }
}
