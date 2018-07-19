using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    //public BallManager ballManager;
    private Text scoreText;
    private int score;

    // Use this for initialization
    void Start () {
        this.scoreText = this.GetComponent<Text>();
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        this.scoreText.text = "Score:" +":"+score.ToString();
	}

    public void AddPoint()
    {
        score++;
    }
}
