﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceManager : MonoBehaviour {

    public GameObject[] obj;
    int count;

    public GameObject lineObject;

    // Use this for initialization
    void Start()
    {
        obj = new GameObject[5];//プリファブ化したものの1つを取り出す実験のために配列になっているだけ
        count = 0;
        obj[count] = Instantiate(lineObject, transform.position, transform.rotation);
        count++;

        Vector3 pos = new Vector3(0, 3, 0);
        GameObject objPlayer = PhotonNetwork.Instantiate("SoccerPlayerPrefab", pos, Quaternion.identity, 0);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
