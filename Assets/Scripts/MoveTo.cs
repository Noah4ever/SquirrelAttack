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
    private Vector3 tempPos;
    public string speedParameterName    = "Speed";
    public string rotationParameterName = "Rotation";
    private void Start()
    {
        tempPos = transform.position;
    }
    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        Vector3 velocity = (transform.position - tempPos) / Time.deltaTime;
        tempPos = transform.position;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        Debug.Log(localVelocity);
        if (agent == null) return;
        animator.SetFloat(speedParameterName, Mathf.Clamp(Vector3.Magnitude(localVelocity) / 3.5f, 0, 1));
        animator.SetFloat(rotationParameterName, Mathf.Clamp(localVelocity.x / 3.5f, -1, 1));

        if (lastPosition == targetPosition.transform.position) return;

        Vector3 newTargetPosition = targetPosition.transform.position;
        
        agent.destination = newTargetPosition;

        lastPosition = newTargetPosition;
    }
}
