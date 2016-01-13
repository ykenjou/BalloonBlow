using UnityEngine;
using System.Collections;

public class TouchWindController : MonoBehaviour {
	
	public GameObject windPrefab;

	GameController gameController;

	void Awake(){
		gameController = GameController.GetController();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(gameController.gamePlayBool){
			if(Input.GetMouseButtonDown(0)){
				Vector3 touchPosition;
				touchPosition = Input.mousePosition;
				touchPosition.z = 10f;

				Instantiate(windPrefab,Camera.main.ScreenToWorldPoint(touchPosition),Quaternion.identity);
			}
		}
	}
}
