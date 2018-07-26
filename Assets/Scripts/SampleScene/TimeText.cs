using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : Photon.MonoBehaviour {


    [SerializeField]
    private int minute;
    [SerializeField]
    public float seconds;
    //　前のUpdateの時の秒数
    private float oldSeconds;
    //　タイマー表示用テキスト
    private Text timerText;

    [SerializeField]
    private int secondsTimeLimit;


    #region monobehaviorメソッド
    // Use this for initialization
    void Start () {
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;
        timerText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {

        if (PhotonNetwork.isMasterClient == false)
        {
            //　値が変わった時だけテキストUIを更新
            if ((int)seconds != (int)oldSeconds)
            {
                timerText.text = "Time " + minute.ToString("00") + ":" + ((int)seconds).ToString("00");
            }

            return;
        }
        Debug.Log("マスターです");


        if(secondsTimeLimit <= seconds)
        {
            Debug.Log("時間になりました");
            return;
        }


        seconds += Time.deltaTime;
        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }
        //　値が変わった時だけテキストUIを更新
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = "Time " + minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
    }
    #endregion

    #region Photon メソッド
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //データの送信
            stream.SendNext(seconds);
        }
        else
        {
            //データの受信
            this.seconds = (float)stream.ReceiveNext();
        }
    }
    #endregion
}
