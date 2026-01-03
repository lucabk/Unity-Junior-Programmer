using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static readonly float TOP_BORDER = 10;
    public static readonly float BOTTOM_BORDER = -8;
    private float lateralMovement = 10f;
    private float jumpForce = 90;
    public float powerupStrength = 50;

    private bool isOnGround = true;
    private bool hasPowerUp = false;
    public static bool gameOver = false;

    private int lives = 3;
    private int powerupDuration = 7;
    
    private Rigidbody playerRb;


    void Start()
    {
        Debug.Log($"Lives: {lives}");
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        ConstraintPlayerPosition();
    }


    private void MovePlayer()
    {
        if(isOnGround && !gameOver)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * lateralMovement * Input.GetAxis("Vertical"));
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }
        }
    }

    private void ConstraintPlayerPosition()
    {
        if(transform.position.z > TOP_BORDER)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, TOP_BORDER);
        } else if (transform.position.z < BOTTOM_BORDER)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, BOTTOM_BORDER);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag) {
            case "Ground":
                isOnGround = true;
                break;
            case "BigEnemy":
            case "Enemy":
            case "LockOnEnemy":
                StoneCollisionHandler(collision.gameObject);
                CheckHealth();
                break;
            default: break;
        }
    }

    private void StoneCollisionHandler(GameObject enemyGameObject)
    {
        if (!hasPowerUp)
        {
            if(enemyGameObject.tag == "LockOnEnemy") 
            {
                gameOver = true;
                lives = 0;
            } else if (enemyGameObject.tag == "BigEnemy")
            {
                Destroy(enemyGameObject);
                lives -= 2;
                Debug.Log($"Lives: {lives}");
            } else
            {
                Destroy(enemyGameObject);
                lives--;
                Debug.Log($"Lives: {lives}");
            }
        } else
        {
            Vector3 repulsiveVersor = (enemyGameObject.transform.position - transform.position).normalized;
            playerRb.AddForce(repulsiveVersor * powerupStrength, ForceMode.Impulse);
        }
    }

    private void CheckHealth()
    {
        if (!gameOver && lives < 0) gameOver = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerUp = true;
            // ADD POWERUP INDICATOR
            StartCoroutine(PowerupCooldown());
        }
    }

    IEnumerator PowerupCooldown()
    {
        yield return new WaitForSeconds(powerupDuration);
        hasPowerUp = false;
    }
}
