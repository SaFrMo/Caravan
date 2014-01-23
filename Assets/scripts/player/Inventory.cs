using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	// The inventory contains not just things the player has, but also events the player has experienced,
	// choices the player has made, and so on.

	public static List<string> inventory = new List<string>() {
		"test"
	};
}
