using UnityEngine;
using System.Collections;

public class WindCircleController : MonoBehaviour {

	CircleCollider2D circleCollider;
	float DestroyInterval;

	// Use this for initialization
	void Start () {
		circleCollider = gameObject.GetComponent<CircleCollider2D>();
		DestroyInterval = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
		circleCollider.radius += Time.deltaTime*2.0f;

		DestroyInterval -= Time.deltaTime;
		if(DestroyInterval < 0){
			Destroy(gameObject);
		}
	}

	void OnCollisionStay2D(Collision2D collision){
		if(collision.gameObject.tag == "Balloon"){
			Destroy(gameObject);
		}
	}
}
