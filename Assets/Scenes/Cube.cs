using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	private float angle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		angle++;
		Vector3 rot = transform.localEulerAngles;
		rot.x = angle;
		rot.y = angle;
		rot.z = angle;
		transform.localEulerAngles = rot;
	}
}
