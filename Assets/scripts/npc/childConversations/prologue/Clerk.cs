using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Clerk : Conversation {

	// this is the string the NPC will say
	string toContent;



	// allow progression to next conversation index
	void AllowContinue () {
		showContinueButton = true;
	}

	void AllowContinue (int where) {
		showContinueButton = true;
		whereTo = where;
	}

	void AllowPlayerLines () {
		showPlayerLine = true;
	}
	
	// HOW TO USE
	// toContent is the string that will actually display in the text box.
	// If the player is allowed to progress to the next line without any choice, call AllowContinue().
	// If the player has something to say, call AllowPlayerLines() and then create:
	// Dictionary<string, int> playerLines = new Dictionary<string, int>() { ... };
	// where each string is the player dialogue choice and each int is the corresponding index of the NPC's response
	protected override void GetContent (int key, out string content, out Dictionary<string, int> playerLines) {

		interruptionOverride = false;
		playerLines = null;
		showContinueButton = false;
		showPlayerLine = false;
		whereTo = -1;

		switch (key) {

		case 0:
			toContent = "There're your things, little miss. You're not so lucky to get out today.";
			AllowPlayerLines();
			playerLines = new Dictionary<string, int>() {
				{ "Why's that?", 1 },
				{ "[Say nothing.]", 1}
			};
			break;
		case 1:
			toContent = "It's raining out there. Not just like, \"Shit, it's raining,\" but like, \"Holy shit, it is <i>raining</i>.\"";
			AllowPlayerLines();
			playerLines = new Dictionary<string, int>() {
				{ "What's the difference?", 2 },
				{ "[Say nothing.]", 2}
			};
			break;
		case 2:
			toContent = "With this kind of rain, they cancel buses. The next one isn't gonna get here until 5 AM tomorrow morning.";
			AllowContinue();
			break;
		case 3:
			toContent = "And I'm sorry, but rules and regulations say we can't let you stay another night. You have to re-ass-imilate, see.";
			AllowContinue();
			break;
		case 4:
			toContent = "But we can give you your things back. Here. We can also give you this old raincoat.";
			AllowContinue();
			break;
		case 5:
			toContent = "Ed, the last janitor before Billy, he left it here a couple months ago, then went home and died that night.";
			AllowContinue();
			break;
		case 6:
			toContent =  "It's like you were meant to have it!";
			AllowPlayerLines();
			playerLines = new Dictionary<string, int>() {
				{ "Thank you.", 7 },
				{ "...I don't want that coat.", 10 }
			};
			break;
		case 7:
			toContent = "Anyway, there's a town about three miles that way. Maybe you can get a bus there.";
			// draw the arrow here
			AllowContinue(8);
			break;
		case 8:
			toContent = "I hate seeing a poor freed woman have to go out walking into the rain. But rules are rules. Take care, sweetie.";
			GameObject transition = GameObject.Find ("Area Transition 1 to 1a");
			transition.GetComponent<AreaTransition>().ForwardLocked (false);
			AllowContinue(12);
			break;
		case 10:
			toContent = "Alright, suit yourself.";
			AllowContinue();
			break;
		case 11:
			Interrupt (GameObject.Find ("Guard"), 50);
			break;

			// added cases
		case 12:
			DoneTalking();
			Advance(13);
			break;

		case 13:
			toContent = "God-damn, it's like you have to leave one prison and head out into another. Sorry, hon.";
			break;


		};

		if (!showConversation)
			showPlayerLine = false;

		content = toContent;
	}
	


	
}
