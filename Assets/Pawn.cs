using UnityEngine;
using System.Collections;

public class Pawn : MonoBehaviour {

	private Vector3 oldPosition;
	private float baseScaleFactor;

	void Start() {
		oldPosition = transform.position;

		baseScaleFactor = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3;
	}
	
	// Update is called once per frame
	void Update () {
		return;

		Vector3 deltaPosition = transform.position - oldPosition;
		Vector3 targetScale = Vector3.zero;

		targetScale.x = (deltaPosition.x / (deltaPosition.y + deltaPosition.z + 1)) * baseScaleFactor;
		targetScale.y = (deltaPosition.y / (deltaPosition.x + deltaPosition.z + 1)) * baseScaleFactor;
		targetScale.z = (deltaPosition.z / (deltaPosition.x + deltaPosition.y + 1)) * baseScaleFactor;

		transform.localScale = targetScale;


		oldPosition = transform.position;
	}
}
