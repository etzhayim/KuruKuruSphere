using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {

    private Rigidbody myRigidbody;
    private float moveForce = 10.0f; //水平の移動力
    private float jumpForce = 15.0f; //ジャンプ力
    private bool locomotion = false; //歩きかジャンプ中の判定

    private GameObject mainCamera;

    private float angVel; //角速度
    private AudioSource sound_gnd, sound_jmp;
    
    // ゲームオーバになる位置
    private float deadLine = -20;
    private float clearLine = -12;

    // Use this for initialization
    void Start () {
        this.myRigidbody = GetComponent<Rigidbody>();
        this.mainCamera = GameObject.Find("Main Camera");
        //オーディオソースを取得
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound_gnd = audioSources[0];
        sound_jmp = audioSources[1];
        sound_gnd.volume = 0;
    }
	
	// Update is called once per frame
	void Update () {
        angVel = myRigidbody.angularVelocity.sqrMagnitude;
        if (!locomotion){
            sound_gnd.volume = 0;
        }else {
            //Debug.Log(angVel);
            if (angVel > 10){
            angVel = 10;
            }
            sound_gnd.volume = angVel/10/3;
        }

        // キー操作
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
        //設置中のみジャンプを受け付ける
        if (Input.GetKeyDown(KeyCode.Space) && locomotion == true)
        {
            this.myRigidbody.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
            sound_jmp.Play(); // ジャンプ音
            locomotion = false;
        }

        // デッドラインを超えた場合ゲームオーバにする
        if (transform.position.y < this.deadLine)
        {
            // UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する
            GameObject.Find("Main Camera").GetComponent<UIController>().GameOver();

        }
        // クリアラインを超えた場合ゲームクリアにする
        if (transform.position.x < this.clearLine)
        {
            if(locomotion){
                // UIControllerのGameClear関数を呼び出して画面上に「GameClear」と表示する
                GameObject.Find("Main Camera").GetComponent<UIController>().GameClear();
            }
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        //設置中動作
        sound_jmp.Play(); // 接地音＝ジャンプと同じ
        locomotion = true;
        if (other.gameObject.tag == "MoveStage"){
        //点数
        this.mainCamera.GetComponent<UIController>().DisplayScore(other.gameObject.GetComponent<KaitenDaiController>().kaitenDaiPoint);
        other.gameObject.GetComponent<KaitenDaiController>().kaitenDaiPoint = 0;
        }
    }

    void OnCollisionExit(Collision other)
    {
        // ジャンプ開始
        locomotion = false;
    }
    
}
