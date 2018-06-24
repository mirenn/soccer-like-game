using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour {

    public GameObject[] obj;
    int count;
    float timer = 0;

    public GameObject lineObject;

	// Use this for initialization
	void Start () {
        obj = new GameObject[5];//プリファブ化したものの1つを取り出す実験のために配列になっているだけ
        count = 0;
        obj[count] = Instantiate(lineObject, transform.position, transform.rotation);
        count++;
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{

            //if (count < 1)
            //{
            //    obj[count] = Instantiate(lineObject, transform.position, transform.rotation);

            //    count++;
            //}
        //}

    }
}
