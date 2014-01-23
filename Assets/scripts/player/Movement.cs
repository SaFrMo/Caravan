using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	/*
	 * FIELDS
	 */

	// hey the sprite, where you goin' to (the -10 is just a flag for an unset goal position; otherwise it'll use the one the user inputs)
	public Vector3 goalPosition = new Vector3 (0, 0, -10f);

	// sprite will be clamped to this Z value, which is set on Start()
	float zValue;
	// acceleration/deceleration rate
	public float walkSpeed = 0.05f;
	// max movement speed
	//public float maxSpeed;
	// current movement speed
	//public float currentSpeed = 0;

	/*
	 * METHODS
	 */
	
	//	Come more-complicated-times, GetPosition() and Move() are going to have
	//		to be updated to reflect different Y values. For now, though, they
	//		are a quick way to move the sprite via mouse clicks.

	void GetPosition () {
		// activate on R mouse click
		if (Input.GetMouseButtonDown(1)) {
			// store click position as the "go to" point for the player
			goalPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			// move toward clicked X, keep at current altitude, and clamp Z value
			goalPosition = new Vector3 (goalPosition.x,
			                            transform.position.y,
			                            zValue);
		}
	}

	void Move () {
		if (transform.position != goalPosition) {
			//currentSpeed = Mathf.Lerp (currentSpeed, maxSpeed, walkSpeed * Time.deltaTime);
			transform.position = Vector3.MoveTowards (transform.position, goalPosition, walkSpeed);
			goalPosition = new Vector3 (goalPosition.x,
			                           transform.position.y,
			                           zValue);
			transform.position = new Vector3 (transform.position.x,
			                                  transform.position.y,
			                                  zValue);
			                                  

		}
	}

	/*
	 * MAKIN' IT HAPPEN
	 */

	void Start () {
		// store starting Z value as the only Z value to use
		zValue = transform.position.z;
		if (goalPosition == new Vector3 (0, 0, -10f))
			goalPosition = transform.position;
	}

	void Update () {
		GetPosition();
		Move();
	}

}
