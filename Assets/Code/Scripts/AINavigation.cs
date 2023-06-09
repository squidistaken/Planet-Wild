using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField]
    LayerMask groundLayer;

    // Patrolling
    Vector3 destPoint;

    bool walkpointSet;

    [SerializeField]
    float walkRange;

    Vector3 position1;
    Vector3 position2;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (!walkpointSet)
        {
            SearchForDest();
        }
        if (walkpointSet)
        {
            agent.SetDestination(destPoint);
        }
        if (Vector3.Distance(transform.position, destPoint) < 10 || agent.velocity.magnitude == 0)
        {
            walkpointSet = false;
        }
    }

	private void SearchForDest()
	{
        float z = Random.Range(-walkRange, walkRange);
		float x = Random.Range(-walkRange, walkRange);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
	}
}
