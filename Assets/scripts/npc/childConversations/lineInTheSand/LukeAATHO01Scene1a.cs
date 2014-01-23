using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LukeAATHO01Scene1a : Conversation {

	// IMPLEMENTATION:
	/* GetContent is the main function here. First, it resets the following values:
	 * 		playerLines: the dictionary<string, int> that contains what a player says and what index that leads to
	 * 		showContinueButton: whether or not the NPC has more to say before the player can chime in
	 * 		showPlayerLine: what the player can say to the NPC
	 * 		whereTo: -1 is a flag value that means clicking on the "next" button will simply advance the conversation by 1.
	 * 			If AllowContinue(int x) is called, -1 will be replaced by x, which will take the conversation to a different
	 * 			place than the next index.
	 * 
	 */

	// this is the string the NPC will say
	string toContent;



	// allow progression to next conversation index
	void AllowContinue () {
		showContinueButton = true;
	}

	// jump to a special index
	void AllowContinue (int where) {
		showContinueButton = true;
		whereTo = where;
	}

	void AllowPlayerLines () {
		showPlayerLine = true;
	}

	// HOW TO USE
	// 1. toContent = what the NPC will say.
	// 2a. If the player is allowed to progress to the next line without any choice, call AllowContinue() or AllowContinue(int where).
	// 2b. If the player has something to say, call AllowPlayerLines() and then create:
	// 		Dictionary<string, int> playerLines = new Dictionary<string, int>() { ... };
	// 		where each string is the player dialogue choice and each int is the corresponding index of the NPC's response
	// 3. If the NPC is to be interrupted, call Interrupt (gameObject interrupter, int lineInterrupterSays); on the relevant case.
	//		Make sure to set conversationIndex on the other character to the one you want them to start out with when you speak with them next.
	protected override void GetContent (int key, out string content, out Dictionary<string, int> playerLines) {

		interruptionOverride = false;
		playerLines = null;
		showContinueButton = false;
		showPlayerLine = false;
		whereTo = -1;

		switch (key) {

		case 0:
			toContent = "Frieda does love to take in strays, doesn't she?";
			AllowPlayerLines();
			playerLines = new Dictionary<string, int>() {
				{ "Who are you?", 1 },
				{ "Who's Frieda?", 1 },
				{ "Back off. Who are you?", 1 }
			};
			break;

		case 1:
			toContent = "She didn't even tell you her name, did she? The woman who took you in is named Frieda. I'm Luke. I'm sort of the bastard child of the family that runs this place. [The man grins, showing his teeth.]";
			AllowContinue();
			break;

		case 2:
			toContent = "I'll bet you she didn't ask <i>your</i> name, either. Am I wrong?";
			AllowPlayerLines();
			playerLines = new Dictionary<string, int>() {
				{ "No. You're right. I guess she didn't.", 3 },
				{ "[Lie] She did. She's considerate.", 4 },
				{ "Fuck you. It's none of your business.", 3 }
			};
			break;

		case 3:
			toContent = "She'll take in a convict without even knowing her name? That seems off, doesn't it?";
			AllowContinue (5);
			break;

		case 4:
			toContent = "I know bullshit when I see it, child. I heard you two.";
			AllowContinue (5);
			break;

		case 5:
			toContent = "She slipped up. She already knows who you are – and your name. She already knows you were coming here. [The man's grin is mainly teeth by this point.]";
			AllowContinue();
			break;

		};

		if (!showConversation)
			showPlayerLine = false;

		content = toContent;
	}
	


	
}
