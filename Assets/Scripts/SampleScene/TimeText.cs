using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : Photon.MonoBehaviour {

    //残り時間
    [SerializeField]
    public float remainingSeconds;
    //　前のUpdateの時の秒数
    private float oldSeconds;
    //　タイマー表示用テキスト
    private Text timerText;



    #region monobehaviorメソッド
    // Use this for initialization
    void Start () {
        oldSeconds = 0f;
        timerText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        remainingSecondsDisp();
        Debug.Log(remainingSeconds);
    }
    #endregion

    #region Photon メソッド
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //データの送信
            stream.SendNext(remainingSeconds);
        }
        else
        {
            //データの受信
            this.remainingSeconds = (float)stream.ReceiveNext();
        }
    }
    #endregion

    #region publicメソッド
    /// <summary>
    /// 時間を減らして表示するメソッド
    /// </summary>
    /// <param name="remainingSeconds"></param>
    /// <param name="timerText"></param>
    /// <param name="oldSeconds"></param>
    private void remainingSecondsDisp()
    {
        //マスタークライアントでないなら処理はしない
        if (PhotonNetwork.isMasterClient == false)
        {
            //　値が変わった時だけテキストUIを更新
            if ((int)remainingSeconds != (int)oldSeconds)
            {
                timerText.text = "TimeLimit " +  ":" + ((int)remainingSeconds).ToString("00");
            }
            return;
        }

        //残り時間がゼロ秒になったら処理終了
        if(remainingSeconds <= 0)
        {
            if ((int)remainingSeconds != (int)oldSeconds)
            {
                timerText.text = "TimeLimit " + ":" + ((int)remainingSeconds).ToString("00");
            }
            return;
        }
        else
        {
            remainingSeconds -= Time.deltaTime;
            Debug.Log(remainingSeconds);
            //値が変わった時のみ、テキスト更新
            if((int)remainingSeconds != (int)oldSeconds)
            {
                timerText.text = "TimeLimit " + ":" + ((int)remainingSeconds).ToString("00");
            }
        }
        oldSeconds = remainingSeconds;

    }
        #endregion
 }
