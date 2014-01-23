using UnityEngine;
using System.Collections;

public class ProximitySensor : MonoBehaviour {

	public int range = 1;

	GameObject player;

	public bool isNearPlayer { get; private set; }


	// save the player gameobject
	void GetPlayer() {
		player = GameObject.Find ("Player");
	}

	// is the player near this sensor?
	void GetNearPlayer () {
		if (Mathf.Abs(player.transform.position.x - transform.position.x ) <= range) {
			isNearPlayer = true;
		}
		else {
			isNearPlayer = false;
		}
	}

	void Start () {
		GetPlayer();
	}

	void Update () {
		GetNearPlayer();
	}
}
