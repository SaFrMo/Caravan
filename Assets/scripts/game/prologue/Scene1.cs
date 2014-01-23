using UnityEngine;
using System.Collections;

public class Scene1 : MonoBehaviour {

	public GameObject scene1;

	void Update () {
		if (GameProgress.GAME_PROGRESS == 1) {
			scene1.SetActive (true);
		}
	}


}
