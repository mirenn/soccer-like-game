using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPlayerController : MonoBehaviour {
    Rigidbody rigid;
    float force = 10.0f;

    Vector3 rightDir = new Vector3(1,0,0);
    Vector3 leftDir = new Vector3(-1, 0, 0);

	// Use this for initialization
	void Start () {
        this.rigid = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () {
        //ジャンプする
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.rigid.AddForce(rightDir*force);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.rigid.AddForce(leftDir*force);
        }
	}
}
