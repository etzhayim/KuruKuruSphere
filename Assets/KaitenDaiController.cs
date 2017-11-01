using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KaitenDaiController : MonoBehaviour {

    [SerializeField]
    private float rotSpeed = 1.0f;  //回転速度
    public int kaitenDaiPoint;

    Rigidbody rg;

    // Use this for initialization
    void Start () {
        rg = GetComponent<Rigidbody>();
        rotSpeed = Random.Range(-2.0f, 2.0f);
        kaitenDaiPoint = (int)(rotSpeed * rotSpeed * 1000) + 100;
    }
	
	// Update is called once per frame
	void Update () {
        // 回転
        //this.transform.Rotate(0, this.rotSpeed, 0);
        rg.angularVelocity = new Vector3(0, this.rotSpeed, 0);
    }

}
