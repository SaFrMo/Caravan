using UnityEngine;
using System.Collections;

public class AreaTransition : MonoBehaviour {

	// newCamera is the area to transition to. oldCamera is the area to transition from.
	public GameObject newCamera;
	public GameObject oldCamera;

	// becomes true on right click. Must be true to change scene.
	bool toChangeScene = false;

	// set this to false and modify from a case in a conversation if a circumstance must be met first
	public bool canGoForward = true;

	// accessor for going forward
	public void ForwardLocked (bool isLocked) {
		canGoForward = !isLocked;
	}

	// if yes, can go between two areas. otherwise, it's a one-way trip (ie locked door, etc)
	public bool canGoBack = true;

	// accessor for going back
	public void BackwardLocked (bool isLocked) {
		canGoBack = !isLocked;
	}

	// moves to new camera
	void SwitchCamera () {
		// to switch back, camera must be at new position and going back must be allowed
		if (Camera.main.transform.position == newCamera.transform.position && canGoBack)
			Camera.main.transform.position = oldCamera.transform.position;
		// otherwise, default to just switching to the new camera position
		else {
			if (canGoForward)
				Camera.main.transform.position = newCamera.transform.position;
		}
	}

	void OnMouseOver () {
		// this is the same button as "move player here," so clicking on a "change scene" button
		if (Input.GetMouseButtonDown (1)) {
			toChangeScene = true;
		}
	}

	void Update () {
		// player must (a) be near area transition sprite and (b) have clicked area transition sprite to change areas
		if (toChangeScene && GetComponent<ProximitySensor>().isNearPlayer) {
			SwitchCamera ();
			// reset the area transition flag to prevent camera jumping
			toChangeScene = false;
		}
	}

}
