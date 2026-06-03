using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    GameObject player;

    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().gameObject;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        navMeshAgent.destination = player.transform.position;
    }
}
