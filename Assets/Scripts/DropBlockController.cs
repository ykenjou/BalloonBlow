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
		if(gameController.gameResetBool){
			if(resetBool){
				transform.position = startPosition;
				resetBool = false;
				rb.velocity = Vector3.zero;
				rb.gravityScale = 0.0f;
			}
		}
	}

	void OnWillRenderObject(){
		if(Camera.current.tag == "MainCamera"){
			rb.gravityScale = 0.1f;
			resetBool = true;
		} else {
			rb.gravityScale = 0.0f;
			rb.velocity = Vector3.zero;
		}
	}
}
