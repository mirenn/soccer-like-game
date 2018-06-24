using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObjectController : MonoBehaviour {

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }
	// Use this for initialization
	void Start () {
        Shoot(new Vector3(400, 100,0));
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 5);
    }
}
