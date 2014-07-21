using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIMove : MonoBehaviour {

	private float moveSpeed = PawnManager.PawnMoveSpeed;
	private float rotateSpeed = PawnManager.PawnRotateSpeed;
	private float wallTolerance = PawnManager.ColisionTolerance;
	
	private int direction_delay = 0;

	private string[] Directions = {"left", "right", "front", "back"};
	private string current_direction = "";

	private Transform targetTransform;
	
	// Update is called once per frame
	void Update () {
		direction_delay -= 1;

		Transform targetTransform = transform;
		if (direction_delay <= 0) {
			randomDirection ();
			resetDelay();

			switch(current_direction) {
			case "left":
				targetTransform.Rotate (new Vector3 (0, - 90, 0));
				break;
			case "right":
				targetTransform.Rotate (new Vector3 (0, 90, 0));
				break;
			case "front":

				break;
			case "back":
				transform.Rotate (new Vector3 (0, - 180, 0));
				break;
			}
		}


		transform.rotation = Quaternion.Slerp (transform.rotation, targetTransform.rotation, Time.time * rotateSpeed);

		moveForward ();

	}

	void moveForward() {
		if (! Physics.Raycast(transform.position, transform.forward, wallTolerance)){
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		}
	}

	void randomDirection() {
		current_direction = Directions [Random.Range (0, Directions.Length)];
	}

	void resetDelay() {
		direction_delay = Random.Range (30, 60);
	}
}
