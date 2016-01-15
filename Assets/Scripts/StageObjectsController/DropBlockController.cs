using UnityEngine;
using System.Collections;

public class DropBlockController : MonoBehaviour {

	Rigidbody2D rb;
	Vector3 startPosition;
	bool resetBool;

	GameController gameController;

	void Awake(){
		gameController = GameController.GetController();
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		startPosition = transform.position;
		resetBool = true;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(rb.gravityScale);
		if(gameController.gameResetBool){
			if(resetBool){
				transform.position = startPosition;
				resetBool = false;
				rb.velocity = Vector3.zero;
				rb.gravityScale = 0.0f;
			}
		}
	}

	void OnBecameVisible(){
		if(Camera.current.tag == "MainCamera"){
			//Debug.Log(Camera.current.tag + " in");
			rb.gravityScale = 0.1f;
			resetBool = true;
		}
	}

	void OnBecameInvisible(){
		//if(Camera.current.tag == "MainCamera"){
			//Debug.Log(Camera.current.tag + " out");
			rb.gravityScale = 0.0f;
			rb.velocity = Vector3.zero;
		//}
	}
}
