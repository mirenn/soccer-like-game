using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class CylinderLineTrack : MonoBehaviour {

    GameObject refObj;
    public NavMeshAgent agent = null;
    NavMeshPath targetPath;
    GameObject refLineObj;
    float playerToPointDistance;
    int targetLinePointCount;
    LineObject t1;
    LineController g1;
    Rigidbody rigidbodyCylinder;


    //RigidBodyを切る実装をしようと思う
    Coroutine coroutine;

    void OnEnable()
    {
        coroutine = StartCoroutine(UpdateNavmesh());
    }

    void OnDisable()
    {
        StopCoroutine(coroutine);
    }
    IEnumerator UpdateNavmesh()
    {
        var agentRigidBody = agent.GetComponent<Rigidbody>();
        agentRigidBody.isKinematic = true;

        yield return null;
    }

    // Use this for initialization
    void Start () {
        refObj = GameObject.Find("LineObject");
        refLineObj = GameObject.Find("LineController");
        agent = GetComponent<NavMeshAgent>();
        playerToPointDistance = 10;
        targetLinePointCount = 0;
        t1 = refObj.GetComponent<LineObject>();
        g1 = refLineObj.GetComponent<LineController>();
        rigidbodyCylinder = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (t1.targetPoints.Count>= 1)
        {   
            if (g1.obj[0] != null)
            {
                LineObject t2 = g1.obj[0].GetComponent<LineObject>();

                if(t2.targetPoints.Count >= 1)
                {
                    targetPath = new NavMeshPath();
                    agent.SetDestination(t2.targetPoints[0]);
                    agent.CalculatePath(t2.targetPoints[0], targetPath);
                    //Debug.Log("残り距離をみています");
                    //Debug.Log(agent.remainingDistance);

                    var destinationVec = t2.targetPoints[0] - transform.position;
                    destinationVec = destinationVec.normalized;
                    if(t2.targetPoints.Count > 1)
                    //rigidbodyCylinder.AddForce(destinationVec*10);
                    if (agent.remainingDistance < 0.5)
                    {
                        
                        //if(targetLinePointCount<t2.targetPoints.Count-1)
                        //targetLinePointCount++;
                        
                    }

                }

            }

        }


    }


}
