using UnityEngine;
using System.Collections;

public class LerpFollow : MonoBehaviour {

	public GameObject Target;

	private float speed = 0.3f;
	private Vector3 dist;

	// Use this for initialization
	void Start () {
		dist = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (! Target) {
			return;
		}

		transform.position = Vector3.Lerp (transform.position, Target.transform.position + dist, speed);
	}
}
