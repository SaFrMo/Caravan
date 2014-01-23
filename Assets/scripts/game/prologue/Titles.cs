using UnityEngine;
using System.Collections;

public class Titles : MonoBehaviour {

	public Texture2D companyLogo;
	public Texture2D gameLogo;


	Timer timer = null;

	int step = 0;

	// 2 seconds black screen
	void Section0 (float length = 2f) {
		// create the timer
		if (timer == null)
			timer = new Timer(length, false);
		// move forward and reset timer
		if (timer.RunTimer()) {
			step++;
			timer = null;
		}
	}

	// 3 seconds company logo
	void Section1 (float length = 3f) {
		if (timer == null)
			timer = new Timer(length, false);
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), companyLogo);
		if (timer.RunTimer()) {
			step++;
			timer = null;
		}
	}

	// 4 seconds game logo
	void Section3 (float length = 4f) {
		if (timer == null)
			timer = new Timer(length, false);
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), gameLogo);
		if (!GetComponent<AudioSource>().isPlaying)
			GetComponent<AudioSource>().Play ();
		

		if (timer.RunTimer()) {
			step++;
			timer = null;
		}
	}

	void OnGUI() {

		if (GameProgress.GAME_PROGRESS == 0) {

			switch (step) {
			case 0:
				Section0 ();
				break;
			case 1:
				Section1 ();
				break;
			case 2:
				Section0 ();
				break;
			case 3:
				Section3 ();
				break;
			case 4:
				//Section0 ();
				GameProgress.Advance();
				break;
			/*case 5:
				GameProgress.Advance();
				break;*/
			};
		}
	}
}
