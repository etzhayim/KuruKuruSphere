using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {

    private Rigidbody myRigidbody;
    private float moveForce = 10.0f;
    private float jumpForce = 10.0f;
    private bool locomotion = false;

    private GameObject FlugCheck;

    // Use this for initialization
    void Start () {
        this.myRigidbody = GetComponent<Rigidbody>();
        this.FlugCheck = GameObject.Find("FlugCheck");
}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.myRigidbody.AddForce(moveForce, 0, 0, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.myRigidbody.AddForce(-moveForce, 0, 0, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.myRigidbody.AddForce(0, 0, moveForce, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.myRigidbody.AddForce(0, 0, -moveForce, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.Space) && locomotion == true)
        {
            this.myRigidbody.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
            this.FlugCheck.GetComponent<DebugText>().check = false;
            locomotion = false;
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        //if (transform.parent == null && other.gameObject.tag == "MoveStage")
        //{
            //var emptyObject = new GameObject();
            //emptyObject.transform.parent = other.gameObject.transform;
            //transform.parent = emptyObject.transform;
            this.FlugCheck.GetComponent<DebugText>().check = true;
        locomotion = true;
        //}
    }

    void OnCollisionExit(Collision other)
    {
        //if (transform.parent != null && other.gameObject.tag == "MoveStage")
        //{
        //    transform.parent = null;
            this.FlugCheck.GetComponent<DebugText>().check = false;
        locomotion = false;
        //}
    }
    
}
