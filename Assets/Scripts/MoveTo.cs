using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    [SerializeField]
    private GameObject targetPosition;
    private Vector3 lastPosition;
    [SerializeField]
    private Animator animator;

    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent == null) return;
        Debug.Log(agent.velocity.sqrMagnitude);
        if (agent.velocity.sqrMagnitude > 1.0)
        {

            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        if (lastPosition == targetPosition.transform.position) return;

        Vector3 newTargetPosition = targetPosition.transform.position;

        // Get current speed of the agent and play animation from that
        
        agent.destination = newTargetPosition;

        lastPosition = newTargetPosition;
    }
}
