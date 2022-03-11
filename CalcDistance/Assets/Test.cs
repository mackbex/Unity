using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, 10f);

        if(col.Length > 0)
        {
            for (int i = 0; i < col.Length; i++)
            {
                Transform tf_Target = col[i].transform;
                if(tf_Target.name == "Player")
                {
                    NavMeshPath path = new NavMeshPath();
                    agent.CalculatePath(tf_Target.position, path);

                    Vector3[] wayPoints = new Vector3[path.corners.Length + 2];
                    wayPoints[0] = transform.position;
                    wayPoints[wayPoints.Length - 1] = tf_Target.position;

                    float _distance = 0f;
                    for (int j = 0; j < path.corners.Length; j++)
                    {
                        wayPoints[j + 1] = path.corners[j];
                        _distance += Vector3.Distance(wayPoints[j], wayPoints[j + 1]);
                    }

                    if(_distance <= 10f)
                    {
                        agent.SetDestination(tf_Target.transform.position);
                    }
                }
            }
        }
    }
}
