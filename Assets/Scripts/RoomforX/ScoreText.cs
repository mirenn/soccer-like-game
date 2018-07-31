using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    public int positiveXScore;
    public int negativeXScore;
    private Text scoreText;

    #region Monobehaviourメソッド
    // Use this for initialization
    void Start () {
        positiveXScore = 0;
        negativeXScore = 0;
        scoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    #endregion

    #region publicメソッド
    public void AddPositiveXScore()
    {
        positiveXScore++;
        Debug.Log(positiveXScore.ToString());
        scoreText.text = "Score" + negativeXScore.ToString() + "-" + positiveXScore.ToString();
    }
    public void AddNegativeXScore()
    {
        negativeXScore++;
        Debug.Log(negativeXScore.ToString());
        scoreText.text = "Score" + negativeXScore.ToString() + "-" + positiveXScore.ToString();
    }
    #endregion
}
