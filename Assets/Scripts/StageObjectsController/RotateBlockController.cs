using UnityEngine;
using System.Collections;

public class RotateBlockController : MonoBehaviour {


	float speed;
	float width;
	float height;

	// Use this for initialization
	void Start () {
		speed = 1f;
		width = 2f;
		height = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		float x = Mathf.Cos(Time.time * speed) * width;
		float y = Mathf.Sin(Time.time * speed) * height;
		float z = 0f;
		transform.position = new Vector3(x,y,z);
	}
}
