using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	GameController gameController;
	public GameObject balloon;
	private Transform balloonTrans;


	void Awake(){
		gameController = GameController.GetController();
	}

	// Use this for initialization
	void Start () {
		balloonTrans = balloon.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameController.gamePlayBool){
			float balloonHeight = balloonTrans.position.y;
			float currentCameraHeight = transform.position.y;
			float newHeight = Mathf.Lerp(currentCameraHeight,balloonHeight,0.5f);
			if(balloonHeight > currentCameraHeight){
				transform.position = new Vector3(transform.position.x,newHeight,transform.position.z);
			}
		}
	}

}
