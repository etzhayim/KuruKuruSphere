using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

    // ゲームオーバテキスト
    private GameObject gameOverText;
    // メインカメラ
    private GameObject mainCamera;
    // 球体オブジェクト
    private Rigidbody sphere;

    // ゲームオーバの判定
    private bool isGameOver = false;

    //スコアを表示するテキスト
    private GameObject scoreText;
    //得点
    private int score = 0;
    private int score_tmp = 0;
    //時間を表示するテキスト
    private GameObject timeText;
    private int min = 0;
    private float sec = 0;
    private int oldsec = 0;

    // Use this for initialization
    void Start () {
        // シーンビューからオブジェクトの実体を検索する
        this.gameOverText = GameObject.Find("GameOver");
        this.mainCamera = GameObject.Find("Main Camera");
        this.sphere = GameObject.Find("Sphere").GetComponent<Rigidbody>();
        this.scoreText = GameObject.Find("ScoreText");
        this.timeText = GameObject.Find("TimeText");

    }
	
	// Update is called once per frame
	void Update () {

        // ゲームオーバになった場合
        if (this.isGameOver)
        {
            // クリックされたらシーンをロードする
            if (Input.GetMouseButtonDown(0))
            {
                //GameSceneを読み込む
                SceneManager.LoadScene("GameScene");
            }
        }

        //獲得した点数を表示
        if(score < score_tmp){
            //スコアの上昇をアニメーションに
            score += 10;        
            this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";
        }

        //プレイ時間を表示
        if(Time.timeScale > 0 && !isGameOver)
        {
            sec += Time.deltaTime;
            if(sec >= 60.0f)
            {
                min++;
                sec -= 60;
            }
            if((int)sec != oldsec)
            {
                this.timeText.GetComponent<Text>().text = "Time: " + min.ToString("00") + ":" + ((int)sec).ToString("00");
            }
        }
    }

    public void GameOver()
    {
        // ゲームオーバになったときに、画面上にゲームオーバを表示する
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        // カメラワーク移動しないようにSphereを固定する
        this.sphere.constraints = RigidbodyConstraints.FreezeAll;
        this.isGameOver = true;
    }
    public void GameClear()
    {
        //ゲームクリア画面
        this.gameOverText.GetComponent<Text>().text = "GameClear!!";
        // カメラワーク移動しないように、KaitenDaiから落ちないようにSphereを固定する
        this.sphere.constraints = RigidbodyConstraints.FreezeAll;
        this.isGameOver = true;
    }

    public void DisplayScore(int addPoint)
    {
        score_tmp += addPoint;
        //獲得した点数を表示 update関数内に移動
        //this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";
    }
}
