using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public event EventHandler<Enemy> OnEnemyDeath;
    public event EventHandler OnAttackStateCurrent;
    public event EventHandler OnAttackStateStopped;
    NavMeshAgent navMeshAgent;
    GameObject player;
    EnemyState previousEnemyState;
    protected EnemyState enemyState;
    bool stateChanged = false;

    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().gameObject;
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyState = EnemyState.Walking;
    }
    void Update()
    {
        if (enemyState != previousEnemyState)
        {
            stateChanged = true;
        }
        previousEnemyState = enemyState;
        switch (enemyState)
        {
            case EnemyState.Walking:
                if (stateChanged)
                {
                    OnAttackStateStopped?.Invoke(this, EventArgs.Empty);
                    navMeshAgent.speed = 3.5f;
                    stateChanged = false;
                }
                
                navMeshAgent.destination = player.transform.position;
            break;
            case EnemyState.Attacking:
                if (stateChanged)
                {
                    OnAttackStateCurrent?.Invoke(this, EventArgs.Empty);
                    navMeshAgent.speed = 0;
                    stateChanged = false;
                }
            break;case EnemyState.OtherStates:
                if (stateChanged)
                {
                    OnAttackStateStopped?.Invoke(this, EventArgs.Empty);
                    navMeshAgent.speed = 0;
                    stateChanged = false;
                }
            break;
        }
    }
    public enum EnemyState
    {
        Walking,
        Attacking,
        OtherStates
    }
}
