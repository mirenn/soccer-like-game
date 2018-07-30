using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeXGoal : MonoBehaviour {

    public ScoreText scoreText;


    #region monobehavor　プロパティ

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
            Debug.Log("NegativeXGoalと接触");
            scoreText.AddPositiveXScore();
        }
    }
    #endregion
}
