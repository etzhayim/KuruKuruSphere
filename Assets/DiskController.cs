using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskController : MonoBehaviour {

    // 回転速度
    private float rotSpeed = 1.0f;
    Rigidbody rg;

    // Use this for initialization
    void Start () {
        rg = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        // 回転
        //this.transform.Rotate(0, this.rotSpeed, 0);
        rg.angularVelocity = new Vector3(0, this.rotSpeed, 0);
    }

}
