using UnityEngine;
using System.Collections;

public class BalloonController : MonoBehaviour {



	Rigidbody2D rb;

	float maxUpSpeed = 0.1f;
	//float maxSlideSpeed = 0.1f;

	GameController gameController;

	void Awake(){
		gameController = GameController.GetController();
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameController.gamePlayBool){
			rb.gravityScale = 0.01f;
		} else {
			rb.gravityScale = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Wind"){
			Vector2 contactPoint =  collision.contacts[0].point;
			Vector3 contactPosition = new Vector3(contactPoint.x,contactPoint.y,0);
			var res = transform.position - contactPosition;
			Vector2 addVector = new Vector2(res.x*40,res.y*40);
			if(rb.velocity.y < maxUpSpeed){
				
			}
			rb.AddForce(addVector);
		}

		if(collision.gameObject.tag == "Destroy"){
			gameObject.SetActive(false);
			gameController.gamePlayBool = false;
			gameController.gameOverBool = true;
		}

		if(collision.gameObject.tag == "Coin"){
			gameController.coinCount++;
			collision.gameObject.SetActive(false);
			Debug.Log("coin hit");
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Coin"){
			gameController.coinCount++;
			other.gameObject.SetActive(false);
		}

		if(other.tag == "Goal"){
			gameController.GameClearFunc();
		}

		if(other.tag == "Destroy"){
			gameObject.SetActive(false);
			gameController.gamePlayBool = false;
			gameController.gameOverBool = true;
		}

		if(other.tag == "Stopper"){
			rb.velocity = Vector3.zero;
		}
	}
}
