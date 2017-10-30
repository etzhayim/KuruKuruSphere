using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour {

    //
    private GameObject FlugCheck;
    public bool check = false;

	// Use this for initialization
	void Start () {
        this.FlugCheck = GameObject.Find("FlugCheck");
      
	}
	
	// Update is called once per frame
	void Update () {

        this.FlugCheck.GetComponent<Text>().text = check.ToString();

	}


}
