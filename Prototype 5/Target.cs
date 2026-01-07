using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private int initialPos = 4;
    private int torqueRange = 10;
    private int outOfBoundLimit = -10;
    public int pointValue;
    
    private Dictionary<string, float> verticalImpulse = new Dictionary<string, float>() { { "MIN", 12f }, { "MAX", 16f } };
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        SetPosition();
        SetVerticalForce();
        SetTorque();
    }

    void Update()
    {
        CheckGameStatus();
    }

    // Called when the user presses the mouse button while over the target's collider
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }


    private void SetPosition()
    {
        transform.position = new Vector2(Random.Range(-initialPos, initialPos), -initialPos);
    }

    private void SetVerticalForce()
    {
        targetRb.AddForce(
            Vector2.up * Random.Range(verticalImpulse["MIN"], verticalImpulse["MAX"]), 
            ForceMode.Impulse
        );
    }

    private void SetTorque()
    {
        Vector3 torqueVector = new Vector3(
            Random.Range(-torqueRange, torqueRange), 
            Random.Range(-torqueRange, torqueRange), 
            Random.Range(-torqueRange, torqueRange)
        );
        targetRb.AddTorque(torqueVector * Time.deltaTime, ForceMode.Impulse);
    }

    private void CheckGameStatus()
    {
        if (transform.position.y < outOfBoundLimit)
        {
            if (gameObject.tag != "Bad") gameManager.GameOver();
            Destroy(gameObject);
        }
    }
}
