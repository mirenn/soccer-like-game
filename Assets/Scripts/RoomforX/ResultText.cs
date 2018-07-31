using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultText : Photon.MonoBehaviour {
    public TimeText timeText;
    public ScoreText scoreText;
    public GameObject resultTextGameObject;
    public Text resultText;

    #region MonoBehavior
    // Use this for initialization
    void Start () {
        //resultTextGameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(timeText.remainingSeconds <= 0)
        {
            Debug.Log("ResultTextゼロ点になったことを観測した");
           // resultTextGameObject.SetActive(true);
            if (PhotonNetwork.isMasterClient)
            {
                //プレイヤーは負のx側
                if(scoreText.negativeXScore > scoreText.positiveXScore)
                {
                    resultText.text = "あなたの勝ち";
                }else if (scoreText.negativeXScore < scoreText.positiveXScore) {
                    resultText.text = "あなたの負け";
                }
                else
                {
                    resultText.text = "引き分け";
                }

            }
            else
            {
                //プレイヤーは正のx 側
                if (scoreText.negativeXScore < scoreText.positiveXScore)
                {
                    resultText.text = "あなたの勝ち";
                }
                else if (scoreText.negativeXScore > scoreText.positiveXScore)
                {
                    resultText.text = "あなたの負け";
                }
                else
                {
                    resultText.text = "引き分け";
                }

            }
        }
	}
    #endregion
}
