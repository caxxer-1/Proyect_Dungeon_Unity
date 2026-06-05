using UnityEngine;

public class HappyEnemy : Enemy
{
    BoxCollider areaOfVision;
    void Start()
    {
        areaOfVision = GetComponent<BoxCollider>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() == null) return;
        enemyState = EnemyState.Attacking;
    }
}
