using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {

	float destroyInterval;
	float sumIntervval;

	// Use this for initialization
	void Start () {
		destroyInterval = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		sumIntervval += Time.deltaTime;
		if(sumIntervval > destroyInterval){
			Destroy(gameObject);
		}
	}
}
