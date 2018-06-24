using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackObjectGenerator : MonoBehaviour {

    public GameObject attackObjectPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject attack = Instantiate(attackObjectPrefab) as GameObject;
            attack.GetComponent<AttackObjectController>().Shoot(
                new Vector3(400, 200, 0)
                );
        }
    }
}
