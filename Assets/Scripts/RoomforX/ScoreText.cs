using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreText : MonoBehaviour {

    private int positiveXScore;
    private int negativeXScore;

    #region Monobehaviourメソッド
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    #endregion

    #region publicメソッド
    public void AddPositiveXScore()
    {
        positiveXScore++;
    }
    public void AddNegativeXScore()
    {
        negativeXScore++;
    }
    #endregion
}
