using UnityEngine;
using System.Collections;

public class KeyboardMove : MonoBehaviour {

	private float moveSpeed = PawnManager.PawnMoveSpeed;
	private float rotateSpeed = PawnManager.PawnRotateSpeed;
	private float wallTolerance = PawnManager.ColisionTolerance;

	// Update is called once per frame
	void Update() {
		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (new Vector3 (0, - rotateSpeed, 0));
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (new Vector3 (0, rotateSpeed, 0));
		}


		if (Input.GetKey (KeyCode.UpArrow)) {
			if (! Physics.Raycast (transform.position, transform.forward, wallTolerance)){
				transform.position += transform.forward * Time.deltaTime * moveSpeed;
			}

		} else if (Input.GetKey (KeyCode.DownArrow)) {
			if (! Physics.Raycast (transform.position, - transform.forward, wallTolerance)){
				transform.position += transform.forward * Time.deltaTime * moveSpeed * - 0.5f;
			}
		}
	}
}
