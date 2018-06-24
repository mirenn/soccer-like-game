using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothControll : MonoBehaviour {

    Rigidbody _rb;
    public bool isUseCameraDirection;    // カメラの向きに合わせて移動させたい場合はtrue
    public float moveSpeed;              // 移動速度
    public float moveForceMultiplier;    // 移動速度の入力に対する追従度
    public GameObject mainCamera;
    float _horizontalInput;
    float _verticalInput;
    Vector3 _moveVector;

    // Use this for initialization
    void Start () {
        this._rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _horizontalInput = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _horizontalInput = 1;
        }
    }

    void FixedUpdate()
    {
        
        Vector3 _moveVector = Vector3.zero; //移動速度の入力
        _moveVector.x = moveSpeed * _horizontalInput;

        _horizontalInput = 0;

        _rb.AddForce(moveForceMultiplier * (_moveVector - _rb.velocity));
    }
}
