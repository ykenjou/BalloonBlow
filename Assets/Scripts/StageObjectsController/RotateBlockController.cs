using UnityEngine;
using System.Collections;

public class RotateBlockController : MonoBehaviour {


	public float speed;
	public float width;
	public float height;

	float timeSum = 0f;

	bool inCameraBool;
	bool resetBool;

	Vector3 startPosition;

	GameController gameController;

	void Awake(){
		gameController = GameController.GetController();
	}

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		resetBool = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameController.gameResetBool){
			if(resetBool){
				transform.position = startPosition;
				resetBool = false;
				timeSum = 0f;
			}
		} else {
			if(inCameraBool && gameController.gamePlayBool){
				timeSum += Time.deltaTime;
				float x = Mathf.Cos(timeSum * speed) * width + startPosition.x;
				float y = Mathf.Sin(timeSum * speed) * height + startPosition.y;
				float z = 0f;
				transform.position = new Vector3(x,y,z);	
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
