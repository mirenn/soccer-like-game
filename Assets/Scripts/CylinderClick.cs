using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderClick : MonoBehaviour {

    GameObject refObj;
    GameObject refLineObj;
    Rigidbody rigidBody;
    public Vector3 force = new Vector3(0, 10, 0);
    public ForceMode forceMode = ForceMode.VelocityChange;
    public bool clickEventFlag;
    public GameObject attackObjectPrefab;
    public bool onPointerEnterFlag;


    // Use this for initialization
    void Start () {
        refObj = GameObject.Find("LineObject");
        refLineObj = GameObject.Find("LineController");

        rigidBody = gameObject.GetComponent<Rigidbody>();
        clickEventFlag = false;
        onPointerEnterFlag = false;
    }
	

	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerClick()
    {
        // GameObject refLineObj = GameObject.Find("LineController");
        Debug.Log("Cylinder Click から来てます");
        LineController g1 = refLineObj.GetComponent<LineController>();
        LineObject t2 = g1.obj[0].GetComponent<LineObject>();
        clickEventFlag = true;

        GameObject attack = Instantiate(attackObjectPrefab) as GameObject;
        attack.GetComponent<AttackObjectController>().Shoot(
            new Vector3(400, 200, 0)
            );
    }

    public void OnPointerEnter()//OnPointerEnter中はこれが実行される
    {
        onPointerEnterFlag = true;
    }
    public void OnPointerExit()
    {
        onPointerEnterFlag = false;
    }
}
