using UnityEngine;
using System.Collections;

public class VerticalMovingController : MonoBehaviour {

	Vector3 velocityA;
	Vector3 velocityB;
	Vector3 startPosition;

	bool inCameraBool;
	bool resetBool;

	Rigidbody2D rb;

	public float velocitySpeed;
	public float moveHeight;

	GameController gameController;

	void Awake(){
		gameController = GameController.GetController();
	}


	// Use this for initialization
	void Start () {
		inCameraBool = false;
		rb = GetComponent<Rigidbody2D>();
		startPosition = transform.position;
		velocityA = new Vector3(0.0f,velocitySpeed,0.0f);
		velocityB = new Vector3(0.0f,-velocitySpeed,0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(gameController.gameResetBool){
			if(resetBool){
				transform.position = startPosition;
				resetBool = false;
				inCameraBool = false;
				rb.velocity = Vector3.zero;
			}
		} else {
			if(inCameraBool){
				if(transform.position.y < startPosition.y -moveHeight && rb.velocity.x <= 0){
					rb.velocity = velocityA;
				} else if(transform.position.y > startPosition.y + moveHeight && rb.velocity.x >= 0){
					rb.velocity = velocityB;
				}
			} else {
				rb.velocity = Vector3.zero;
			}
		}
	}

	void OnBecameVisible(){
		if(Camera.current.tag == "MainCamera"){
			inCameraBool = true;
			resetBool = true;
			rb.velocity = velocityB;
		}
	}

	void OnBecameInvisible(){
		inCameraBool = false;
		rb.velocity = Vector3.zero;
	}
}
