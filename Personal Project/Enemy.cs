using UnityEngine;

public class Enemy : BaseEnemy
{
    protected float speed = 50;

    void Start()
    {
        GetRigidbody();
    }

    void Update()
    {
        Move();
    }


    protected override void Move()
    {
        enemyRb.AddForce(Vector3.left * speed); // INCREMENTA VELOCITA' A SECONDA DEL NUMERO DI NEMICI SPAWNATI
    }
}
