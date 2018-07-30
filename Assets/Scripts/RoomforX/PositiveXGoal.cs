using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositiveXGoal : MonoBehaviour {

    public ScoreText scoreText;

    #region monobehaviorプロパティ

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ball(Clone)")
        {
            Debug.Log("PositiveXGoalに接触");
            scoreText.AddNegativeXScore();
        }
    }

    #endregion
}
