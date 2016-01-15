using UnityEngine;
using System.Collections;

public class ThrowBallController : MonoBehaviour {

	Rigidbody2D rb;
	public Vector2 ballDirection;

	// Use this for initialization
	void Start () {
		ballDirection = new Vector2(100,200);
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(ballDirection);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnBecameInvisible(){
		Destroy(gameObject);
	}
}
