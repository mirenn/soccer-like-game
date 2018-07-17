using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Goal")
        {
            Debug.Log("Goal");
            transform.position = new Vector3(0f, 5f, 0f);
        }
        if (collision.gameObject.name == "GoalFloorPx")
        {
            Debug.Log("Goal");
            transform.position = new Vector3(0f, 5f, 0f);
        }
        if (collision.gameObject.name == "GoalFloorPy")
        {
            Debug.Log("Goal");
            transform.position = new Vector3(0f, 5f, 0f);
        }
    }
}
