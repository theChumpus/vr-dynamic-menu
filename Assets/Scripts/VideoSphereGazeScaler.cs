using UnityEngine;
using System.Collections;

public class VideoSphereGazeScaler : MonoBehaviour {

	Vector3 scaler;

	void Start() {
		scaler = transform.localScale * 0.2f;
	}
	
	public void onGaze(bool gazedAt) {
		if (gazedAt) {
			transform.localScale += scaler;
		} else {
			transform.localScale -= scaler;
		}
	}
}
