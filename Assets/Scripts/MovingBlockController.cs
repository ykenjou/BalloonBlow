using UnityEngine;
using System.Collections;

public class MovingBlockController : MonoBehaviour {

	Vector3 velocityA = new Vector3(2.0f,0.0f,0.0f);
	Vector3 velocityB = new Vector3(-2.0f,0.0f,0.0f);
	Vector3 startPosition;

	bool inCameraBool;
	bool resetBool;

	Rigidbody2D rb;

	GameController gameController;

	void Awake(){
		gameController = GameController.GetController();
	}

	// Use this for initialization
	void Start () {
		inCameraBool = false;
		rb = GetComponent<Rigidbody2D>();
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		if(gameController.gameResetBool){
			if(resetBool){
				transform.position = startPosition;
				resetBool = false;
				inCameraBool = false;
				rb.velocity = Vector3.zero;
			}
		} else {
			if(inCameraBool){
				if(transform.position.x < -2.0f && rb.velocity.x <= 0){
					rb.velocity = velocityA;
				} else if(transform.position.x > 2 && rb.velocity.x >= 0){
					rb.velocity = velocityB;
				}
			} else {
				rb.velocity = Vector3.zero;
			}
		}
	}

	void OnWillRenderObject(){
		if(Camera.current.tag == "MainCamera"){
			inCameraBool = true;
			resetBool = true;
		} else {
			inCameraBool = false;
			rb.velocity = Vector3.zero;
		}
	}
}
