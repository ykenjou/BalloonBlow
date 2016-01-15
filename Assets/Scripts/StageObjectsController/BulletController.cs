using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	Rigidbody2D rb;
	Vector3 bulletDirection;

	GameObject _parent;
	BulletSpotController bulletSpotController;

	float speedRate;

	// Use this for initialization
	void Start () {

		_parent = transform.parent.gameObject;
		bulletSpotController = _parent.GetComponent<BulletSpotController>();
		speedRate = bulletSpotController.speedRate;

		rb = GetComponent<Rigidbody2D>();
		bulletDirection = new Vector3(-1.0f * speedRate,0.0f,0.0f);
		rb.velocity = bulletDirection;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnBecameInvisible(){
		Destroy(gameObject);
	}

}
