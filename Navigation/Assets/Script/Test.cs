using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{

    Rigidbody myRigid;
    [SerializeField] private float moveSpeed;

    NavMeshAgent agent;
    [SerializeField] private Transform[] tf_Destination;

    private Vector3[] wayPoints;
    private Vector3 originPos;

    // Start is called before the first frame update
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        originPos = transform.position;

        wayPoints = new Vector3[tf_Destination.Length + 1];

        for (int i = 0; i < tf_Destination.Length; i++)
        {
            wayPoints[i] = tf_Destination[i].position;
        }

        wayPoints[wayPoints.Length - 1] = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
  
        Patrol();
    }

    private void Patrol()
    {
        for (int i = 0; i < wayPoints.Length; i++)
        {

            if(Vector3.Distance(transform.position, wayPoints[i]) <= 3f)
            {
                agent.SetDestination(wayPoints[(i + 1) % wayPoints.Length]);
            }
        }
    }
}
