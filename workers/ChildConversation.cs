using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BigZ : Conversation {

	// this is the string the NPC will say
	string toReturn;

	// allow progression to next conversation index
	void AllowContinue () {
		showContinueButton = true;
	}
	

	protected override string GetContent (int key) {

		showContinueButton = false;

		switch (key) {

		case 0:
			toReturn = "Hello!";
			AllowContinue();
			break;

		case 1:
			toReturn = "Bye!";
			break;

		};

		return toReturn;
	}



	
}
