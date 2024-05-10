using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    [SerializeField]
    private GameObject targetPosition;
    private Vector3 lastPosition;

    void Update()
    {
        if (lastPosition == targetPosition.transform.position) return;

        Vector3 newTargetPosition = targetPosition.transform.position;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = newTargetPosition;

        lastPosition = newTargetPosition;
    }
}
