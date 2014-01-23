using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BigZ : Conversation {

	// this is the string the NPC will say
	string toContent;



	// allow progression to next conversation index
	void AllowContinue () {
		showContinueButton = true;
	}

	void AllowPlayerLines () {
		showPlayerLine = true;
	}
	

	protected override void GetContent (int key, out string content, out Dictionary<string, int> playerLines) {

		playerLines = null;
		showContinueButton = false;
		showPlayerLine = false;

		switch (key) {

		case 0:
			toContent = "Well! A child of the San Lucas Correctional Facility! It's good to see that the old incubators are still turning out the chicks regularly.";
			AllowContinue();
			break;

		case 1:
			toContent = "Move along, child, there's nothing for you here.";
			AllowPlayerLines();
			playerLines = new Dictionary<string, int>() {
				{ "What!", 0 },
				{ "Wait!", 2 }
			};
			break;
		case 2:
			toContent = "Thanks!";
			break;

		};

		if (!showConversation)
			showPlayerLine = false;

		content = toContent;
	}
	


	
}
