using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController GetController() {
		return GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
	}

	[System.NonSerialized]
	public bool gamePlayBool;
	[System.NonSerialized]
	public bool gameOverBool;
	[System.NonSerialized]
	public bool gameClearBool;
	[System.NonSerialized]
	public bool gameResetBool;
	[System.NonSerialized]
	public int coinCount;
	int oldCoinCount;
	[System.NonSerialized]
	public float timeCount;
	float oldTimeCount;

	public Camera mainCamera;
	public GameObject startPanel;
	public GameObject startBtn;
	public GameObject readyText;
	public GameObject goText;
	public GameObject gameStartPanel;
	public GameObject gameOverPanel;
	public GameObject gameClearPanel;
	public GameObject balloon;
	public GameObject startPoint;
	public GameObject cameraStartPoint;
	public Text coinText;
	public Text timeText;
	Rigidbody2D balloonRb;

	GameObject[] coins;

	// Use this for initialization
	void Start () {
		coins = GameObject.FindGameObjectsWithTag("Coin");
		balloonRb = balloon.GetComponent<Rigidbody2D>();
		GameResetFunc();
		Application.targetFrameRate = 60;
	}
	
	// Update is called once per frame
	void Update () {
		if(gamePlayBool){
			if(coinCount != oldCoinCount){
				coinText.text = coinCount.ToString();
				oldCoinCount = coinCount;
			}

			timeCount += Time.deltaTime;
			if(oldTimeCount != timeCount){
				timeText.text = timeCount.ToString("f1");
				oldTimeCount = timeCount;
			}
		}

		if(gameOverBool){
			GameOverFunc();
		}
	}

	public void GameResetFunc(){
		gamePlayBool = false;
		gameOverBool = false;
		gameClearBool = false;
		gameResetBool = true;
		gameStartPanel.SetActive(true);
		gameOverPanel.SetActive(false);
		gameClearPanel.SetActive(false);
		goText.SetActive(false);
		readyText.SetActive(true);
		startBtn.SetActive(true);
		coinCount = 0;
		coinText.text = "0";
		timeCount = 0;
		oldTimeCount = 0;
		timeText.text = "0.0";
		balloon.SetActive(true);
		balloon.transform.position = startPoint.transform.position;
		mainCamera.transform.position = cameraStartPoint.transform.position;
		foreach(GameObject coin in coins){
			if(coin.activeSelf == false){
				coin.SetActive(true);
			}
		}
		balloonRb.velocity = new Vector3(0,0,0);

	}

	public void GameStartFunc(){
		StartCoroutine("StartStream");
	}

	void GameOverFunc(){
		gameOverBool = false;
		gameOverPanel.SetActive(true);
	}

	public void GameClearFunc(){
		gameClearPanel.SetActive(true);
		gamePlayBool = false;
	}

	IEnumerator StartStream(){
		gameResetBool = false;
		readyText.SetActive(false);
		goText.SetActive(true);
		startBtn.SetActive(false);
		yield return new WaitForSeconds(1.0f);
		goText.SetActive(false);
		gamePlayBool = true;
	}
}
