using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3;
    private Rigidbody enemyRb;
    private GameObject player;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
        DestroyFallenEnemy();
    }

    private void DestroyFallenEnemy()
    {
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
