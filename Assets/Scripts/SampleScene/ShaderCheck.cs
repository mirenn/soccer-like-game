using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.SetColor("_BaseColor", Color.red);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
