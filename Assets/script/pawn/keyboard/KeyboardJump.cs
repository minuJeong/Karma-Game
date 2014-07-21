using UnityEngine;
using System.Collections;

public class KeyboardJump : MonoBehaviour {

	private float jumpPower = 500.0f;
	private float groundTolerance = 0.5f;
	
	private const float init_jump_minimun_wait = 10;
	private float jump_minimum_wait = init_jump_minimun_wait;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		jump_minimum_wait -= 1;
		if ( Input.GetKey (KeyCode.Space)) {
			if (Physics.Raycast(transform.position, -Vector3.up, groundTolerance) && jump_minimum_wait <= 0) {
				jump_minimum_wait = init_jump_minimun_wait;
				rigidbody.AddForce(Vector3.up * jumpPower);
			}
		}
	}
}
