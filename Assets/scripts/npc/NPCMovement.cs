using UnityEngine;
using System.Collections;

public class NPCMovement : MonoBehaviour {

	public Vector3 goalPosition;

	public float movementRate = .05f;

	void Start () {
		goalPosition = transform.position;
	}

	void Update () {
		if (transform.position != goalPosition) {
			transform.position = Vector3.MoveTowards (transform.position, goalPosition, movementRate);
		}
	}
}
