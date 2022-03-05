using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GuardControl : MonoBehaviour
{
    public float speed;
    public Transform target;
    public Transform[] patrolPoints;
    public float timeStun = 10f;
    int pointsIndex;
    float resetSpeed;
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
        if(resetSpeed < Time.time)
        {
            agentGuard.speed = speed;
        }
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

    void OnTriggerEnter(Collider obj) {
        Debug.Log(obj.name);
        if (obj.name == "Player") {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("LoseScene");
        }
    }

    public void Stun()
    {
        agentGuard.speed = 0;
        resetSpeed = Time.time + timeStun;
    }
}
