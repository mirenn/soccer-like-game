using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {

    public int score;
    public ScoreManager scoreManager;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 0, 3), ForceMode.Impulse);
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
            score++;
            scoreManager.AddPoint();
        }
        if (collision.gameObject.name == "PositiveXGoal")
        {
            Debug.Log("Goal");
            transform.position = new Vector3(0f, 5f, 0f);
        }
        if (collision.gameObject.name == "NegativeXGoal")
        {
            Debug.Log("Goal");
            transform.position = new Vector3(0f, 5f, 0f);
        }
    }
}
