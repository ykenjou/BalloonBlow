using UnityEngine;
using System.Collections;

public class BulletSpotController : MonoBehaviour {

	public GameObject bulletPrefab;

	public float IntervalTimeDefault = 3.0f;
	float intervalTime = 0.0f;

	bool inCameraBool;
	bool resetBool;

	GameController gameController;

	public float speedRate;
	public float speedX = -1.0f;

	void Awake(){
		gameController = GameController.GetController();
	}

	// Use this for initialization
	void Start () {
		inCameraBool = false;
		resetBool = false;
		intervalTime = IntervalTimeDefault;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameController.gameResetBool){
			if(resetBool){
				resetBool = false;
				intervalTime = IntervalTimeDefault;
			}
		} else {
			if(inCameraBool && gameController.gamePlayBool){
				intervalTime += Time.deltaTime;
				if(intervalTime > IntervalTimeDefault){
					intervalTime = 0.0f;
					ShotBullet();
				}
			}
		}
	}

	void ShotBullet(){
		GameObject bullet = GameObject.Instantiate(bulletPrefab,new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity) as GameObject;
		bullet.transform.SetParent(transform);
	}

	void OnBecameVisible(){
		if(Camera.current.tag == "MainCamera"){
			inCameraBool = true;
			resetBool = true;
		}
	}

	void OnBecameInvisible(){
		inCameraBool = false;
	}
}
