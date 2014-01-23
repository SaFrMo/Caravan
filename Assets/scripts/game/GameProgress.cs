using UnityEngine;
using System.Collections;

public class GameProgress : MonoBehaviour {

	public int jumpTo = 0;

	void Start () {
		GAME_PROGRESS = jumpTo;
	}

	public static int GAME_PROGRESS;

	public static void Advance() {
		GameProgress.GAME_PROGRESS++;
	}
}
