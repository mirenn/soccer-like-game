using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerPlayerClick : MonoBehaviour {

    GameObject refObj;
    GameObject refLineObj;
    Rigidbody rigidBody;
    public Vector3 force = new Vector3(0, 10, 0);
    public ForceMode forceMode = ForceMode.VelocityChange;
    public bool clickEventFlag;
    public bool onPointerEnterFlag;


    // Use this for initialization
    void Start()
    {
        refObj = GameObject.Find("LineRenderObjectPrefab");
        refLineObj = GameObject.Find("InstanceManager");

        rigidBody = gameObject.GetComponent<Rigidbody>();
        clickEventFlag = false;
        onPointerEnterFlag = false;
    }


    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick()
    {
        // GameObject refLineObj = GameObject.Find("LineController");
        Debug.Log("OnPointerClick から来てます");
        clickEventFlag = true;
    }

    public void OnPointerEnter()//OnPointerEnter中はこれが実行される
    {
        Debug.Log("OnPointerEnterから来ています");
        onPointerEnterFlag = true;
    }
    public void OnPointerExit()
    {
        onPointerEnterFlag = false;
    }

}
