using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class wander : MonoBehaviour
{
    public NavMeshAgent agent;
    public float radius, offset;

    void Update()
    {
        Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
        localTarget += new Vector3(0, 0, offset);
        Vector3 worldTarget = transform.TransformPoint(localTarget);
        worldTarget.y = 0f;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(worldTarget, out hit, 3.0f, NavMesh.AllAreas))
        {
            worldTarget = hit.position;
        }
        else
        {
            localTarget = localTarget * -1;
            worldTarget = transform.TransformPoint(localTarget);
        }
        Seek(worldTarget);
    }

    void Seek(Vector3 v)
    {
        agent.destination = v;
    }
}
