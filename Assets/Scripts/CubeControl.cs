using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class CubeControl : MonoBehaviour
{

    Rigidbody rigidBody;
    public Vector3 force = new Vector3(0, 10, 0);
    public ForceMode forceMode = ForceMode.VelocityChange;

    // Use this for initialization
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();

    }
    public void OnUserAction()
    {
        Debug.Log("成功！！！！！！！！！！！！！！１１");
        rigidBody.AddForce(force, forceMode);
    }
}