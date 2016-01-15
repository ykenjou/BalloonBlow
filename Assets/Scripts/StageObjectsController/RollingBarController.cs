using UnityEngine;
using System.Collections;

public class RollingBarController : MonoBehaviour {

	bool inCameraBool;
	bool resetBool;
	int rotateSpeed;

	float rotateAngle;

	GameController gameController;

	void Awake(){
		gameController = GameController.GetController();
	}

	// Use this for initialization
	void Start () {
		resetBool = false;
		rotateAngle = 0.0f;
		rotateSpeed = 20;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameController.gameResetBool){
			if(resetBool){
				transform.rotation = Quaternion.Euler(0,0,0);
				resetBool = false;
				inCameraBool = false;
				rotateAngle = 0.0f;
			}
		} else {
			if(inCameraBool){
				rotateAngle += Time.deltaTime * rotateSpeed;
				transform.rotation = Quaternion.Euler(0,0,rotateAngle);
			}
		}
	}

	void OnBecameVisible(){
		if(Camera.current.tag == "MainCamera"){
			inCameraBool = true;
			resetBool = true;
		}
	}

	void OnBecameInvisible(){
		inCameraBool = false;
	}
}
