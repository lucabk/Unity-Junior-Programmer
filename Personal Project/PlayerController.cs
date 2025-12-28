using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float lateralMovement = 10f;
    private float jumpForce = 60;
    private static readonly float TOP_BORDER = 1.5f;
    private static readonly float BOTTOM_BORDER = -4.5f;
    private bool isOnGround = true;
    private Rigidbody playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        ConstraintPlayerPosition();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void MovePlayer()
    {
        if(isOnGround)
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
}
