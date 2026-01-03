using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    protected Rigidbody enemyRb;

    protected void GetRigidbody()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    protected virtual void Move()
    {
    }
}
