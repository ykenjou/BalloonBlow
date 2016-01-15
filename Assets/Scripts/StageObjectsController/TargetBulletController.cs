using UnityEngine;
using System.Collections;

public class TargetBulletController : MonoBehaviour {

	Rigidbody2D rb;
	Vector3 bulletPosition;
	Vector3 bulletDirection;
	Vector3 balloonPosition;
	Vector3 bulletSpeedDirection;
	GameObject balloon;
	float speedRate;

	GameObject _parent;
	BulletSpotController bulletSpotController;

	// Use this for initialization
	void Start () {

		_parent = transform.parent.gameObject;
		bulletSpotController = _parent.GetComponent<BulletSpotController>();
		speedRate = bulletSpotController.speedRate;

		rb = GetComponent<Rigidbody2D>();
		balloon = GameObject.FindGameObjectWithTag("Balloon");
		balloonPosition = balloon.transform.position;
		bulletPosition = transform.position;
		bulletDirection = (balloonPosition - bulletPosition).normalized;
		bulletSpeedDirection = new Vector3(bulletDirection.x * speedRate,bulletDirection.y * speedRate,bulletDirection.z);
		rb.velocity = bulletSpeedDirection;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnBecameInvisible(){
		Destroy(gameObject);
	}
}
