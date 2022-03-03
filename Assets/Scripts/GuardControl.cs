using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardControl : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Transform[] patrolPoints;
    int pointsIndex;
    NavMeshAgent agentGuard;

    // Start is called before the first frame update
    void Start()
    {
        agentGuard = this.GetComponent<NavMeshAgent>();
        agentGuard.autoBraking = false;

        agentGuard.speed = speed;
        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        SetDestination();
    }

    public void SetTarget(Transform s)
    {
        target = s;
        SetDestination();
    }

    void GoToNext()
    {
        if(patrolPoints.Length == 0)
        {
            return;
        }
        agentGuard.destination = patrolPoints[pointsIndex].position;
        pointsIndex = (pointsIndex+1)%patrolPoints.Length;
    }

    void SetDestination()
    {
        if (target != null)
        {
            Vector3 targetVector = target.position;
            agentGuard.SetDestination(targetVector);
        } else
        {
            if(!agentGuard.pathPending && agentGuard.remainingDistance < 0.5f)
            {
                GoToNext();
            }
        }
    }
}
