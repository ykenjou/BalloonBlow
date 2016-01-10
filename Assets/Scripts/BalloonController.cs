using UnityEngine;
using System.Collections;

public class BalloonController : MonoBehaviour {

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Wind"){
			Vector2 contactPoint =  collision.contacts[0].point;
			Vector3 contactPosition = new Vector3(contactPoint.x,contactPoint.y,0);
			var res = transform.position - contactPosition;
			Vector2 addVector = new Vector2(res.x*40,res.y*40);
			//Debug.Log(res);
			rb.AddForce(addVector);
			//Debug.Log("wind:" + contactPosition);
			//Debug.Log("balloon:" + transform.position);
		}
	}
}
