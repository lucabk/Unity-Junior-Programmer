using UnityEngine;

public class LockOnEnemy : BaseEnemy
{
    protected float speed = 20;

    private GameObject player;

    void Start()
    {
        GetRigidbody();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Move();
    }


    protected override void Move()
    {
        if(transform.position.x < player.transform.position.x)
        {
            enemyRb.AddForce(Vector3.left * speed);
        } else
        {
            Vector3 toPlayerVersor = (player.gameObject.transform.position - transform.position).normalized;
            enemyRb.AddForce(toPlayerVersor * speed);
        }
    }
}
