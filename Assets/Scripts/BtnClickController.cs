using UnityEngine;
using System.Collections;

public class BtnClickController : MonoBehaviour {

	GameController gameController;

	void Awake(){
		gameController = GameController.GetController();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ClickStartBtn(){
		gameController.GameStartFunc();
	}

	public void ClickRestartBtn(){
		gameController.GameResetFunc();
	}
}
