using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    // メインカメラオブジェクト
    private GameObject mainCamera;
    // 球体オブジェクト
    private GameObject sphere;
    // カメラと球体の距離
    private float delta_x;
    private float delta_z;
    private float offset_z = -20;

    // Use this for initialization
    void Start () {
        this.mainCamera = GameObject.Find("Main Camera");
        this.sphere = GameObject.Find("Sphere");
    }
	
	// Update is called once per frame
	void Update () {
        //カメラワークの設定
        delta_x = this.mainCamera.transform.position.x - this.sphere.transform.position.x;
        if(delta_x > 5)
        {
            mainCamera.transform.position -= new Vector3(delta_x - 5, 0, 0);
        } else if(delta_x < -5)
        {
            mainCamera.transform.position -= new Vector3(delta_x + 5, 0, 0);
        }
        delta_z = (this.mainCamera.transform.position.z - offset_z) - this.sphere.transform.position.z;
        if (delta_z > 5)
        {
            mainCamera.transform.position -= new Vector3(0, 0, delta_z - 5);
        }
        else if (delta_z < -5)
        {
            mainCamera.transform.position -= new Vector3(0, 0, delta_z + 5);
        }
    }
}
