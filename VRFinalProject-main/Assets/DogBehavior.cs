using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogBehavior : MonoBehaviour
{
    public Transform patrolRoute;
    public List<Transform> locations;
    private int locationIndex = 0;
    private NavMeshAgent agent;
    public Transform player;
    private bool playerInside = false;
    public float patrolSpeed = 5.0f;
    public float chaseSpeed = 1.0f;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 5.0f;
        InitializePatrolRoute();
        player = GameObject.Find("PlayerController").transform;
    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0)
            return;

        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerController")
        {
            //agent.destination = player.position;
            Debug.Log("Player detected - attack!");
            playerInside = true;  
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "PlayerController")
        {
            Debug.Log("Player out of range, resume patrol");
            playerInside = false;  
        }
    }

    void Update()
    {
        if (!playerInside)
        {
            // When the player is not inside, continue patrolling
            if (agent.remainingDistance < 0.2f && !agent.pathPending)
            {
                agent.speed = patrolSpeed;
                MoveToNextPatrolLocation();
            }
        }
        else
        {
            // Only chase the player when they are inside the collider
            agent.speed = chaseSpeed;
            Vector3 directionToPlayer = player.position - agent.transform.position;
            Vector3 normalizedDirection = directionToPlayer.normalized;
            Vector3 destinationOffset = player.position - normalizedDirection * 1.2f;
            agent.destination = destinationOffset;
        }
    }
}

