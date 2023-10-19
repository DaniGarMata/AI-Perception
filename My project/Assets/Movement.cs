using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public float radius, offset;
    public bool chase = false;
    public GameObject target;

    void Update()
    {
        if (chase)
        {
            agent.destination = target.transform.position;
        }
        else
        {
            Vector3 localTarget = UnityEngine.Random.insideUnitCircle * radius;
            localTarget += new Vector3(0, 0, offset);
            Vector3 worldTarget = transform.TransformPoint(localTarget);
            worldTarget.y = 0f;
            UnityEngine.AI.NavMeshHit hit;
            if (UnityEngine.AI.NavMesh.SamplePosition(worldTarget, out hit, 3.0f, UnityEngine.AI.NavMesh.AllAreas))
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

    }

    void Seek(Vector3 v)
    {
        agent.destination = v;
    }

    void Chase()
    {
        chase = true;
    }
}
