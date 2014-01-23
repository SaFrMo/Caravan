using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriedaAATHO01Scene1 : Conversation {

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
			toContent = "Evening. We were about to close up just now, but I'm not one to turn away a customer. You got your eye on anything in particular, hon?";
			AllowPlayerLines();
			playerLines = new Dictionary<string, int>() {
				{ "I'm not sure. What do you do here?", 1 },
				{ "No, I'm trying to get out of the rain.", 8 },
				{ "No, I'm looking for a ride.", 9 }
			};
			break;

		case 1:
			toContent = "[The woman puts her hands on her hips and cocks her head.] Used cars, little lady. Nobody in the parking lot, so you must've got here on foot. You got any cash? What's your plan?";
			AllowPlayerLines();
			playerLines = new Dictionary<string, int>() {
				{ "I just got out of prison. I don't have a ride, and they didn't send a bus.", 2 }
			};
			break;

		case 2:
			toContent = "God damn. No family or anything?";
			AllowPlayerLines();
			playerLines = new Dictionary<string, int>() {
				{ "None that'll give me a ride.", 24 },
				{ "No. No more.", 3 },
				{ "[Say nothing.]", 24 }
			};
			break;

		case 3:
			// resets the crime's lie status, in case the player decides to go back
			if (Inventory.inventory.Contains ("Lied about crime"))
				Inventory.inventory.Remove ("Lied about crime");

			toContent = "Damnation. I wish I could help. Must be a hell of a readjustment. What were you in for, if you don't mind my asking?";
			AllowPlayerLines();
			playerLines = new Dictionary<string, int>() {
				{ "[Lie] I was in for...", 25 },
				{ "[Truth] I was in for...", 26 },
				{ "I'd rather not say.", 7 }
			};
			break;

		case 4:
			toContent = "Huh. That don't seem too bad.";
			if (!(Inventory.inventory.Contains ("Crime: Tax fraud")))
				Inventory.inventory.Add ("Crime: Tax fraud");
			AllowContinue(10);
			break;

		case 5:
			toContent = "Oh, you poor thing. I've got some family that fell into all that when I was younger. Complicated thing.";
			if (!(Inventory.inventory.Contains ("Crime: Drugs")))
				Inventory.inventory.Add ("Crime: Drugs");
			AllowContinue(10);
			break;

		case 6:
			toContent = "Huh. You may have to tell me the whole story at some point.";
			if (GameObject.Find ("Frieda").GetComponent<NPCInventory>().inventory.Contains ("Doubt about player's family"))
				toContent += " Sounds like there's a nuance or two there.";
			else
				toContent += " I hear you on family, though.";
			if (!Inventory.inventory.Contains ("Crime: Family troubles"))
				Inventory.inventory.Add ("Crime: Family troubles");
			AllowContinue(10);
			break;

		case 7:
			toContent = "Can't say I blame you.";
			AllowContinue(10);
			break;

		case 8:
			toContent = "Well, you managed that much. Supposed to keep raining, though. You got any cash? What's your plan?";
			AllowPlayerLines();
			playerLines = new Dictionary<string, int>() {
				{ "My sentence is up today. I don't have a ride, and they didn't send a bus.", 2 }
			};
			break;

		case 9:
			toContent = "I can sell you one, but you don't look like the cash-carrying type. What's your plan?";
			AllowPlayerLines();
			playerLines = new Dictionary<string, int>() {
				{ "My sentence is up today. I don't have a ride, and they didn't send a bus.", 2 }
			};
			break;

		case 10:
			toContent = "Well, listen, I can't give you a ride, but the rain's only supposed to keep coming tonight, and I don't want you hounded by the folks over at Big Mountain.";
			if (Inventory.inventory.Contains ("Crime: Tax fraud"))
				toContent += " You don't quite sound the violent type. Even so, y";
			else if (Inventory.inventory.Contains ("Crime: Drugs"))
				toContent += " The jail throw you back on the street after all you've been through and just expect you to be fine. Makes me sick. Y";
			else if (Inventory.inventory.Contains ("Crime: Family troubles"))
				toContent += " That and I believe in giving people second chances. Y";
			else
				toContent += " Y";
			toContent += "ou'll understand if we keep an eye on you, but you can camp out in our break room tonight. Rain should at least slow by tomorrow morning.";
			AllowPlayerLines ();
			playerLines = new Dictionary<string, int>() {
				{ "But you don't even know me.", 11 }
			};
			break;

		case 11:
			toContent = "Well, I know someone in a bind when I see her, and I know when someone else can help her out. Head to the washroom and clean yourself up a bit; I'll tidy up the break room.";
			AllowPlayerLines();
			playerLines = new Dictionary<string, int>() {
				{ "Thank yo – ", 12 },
				{ "I apprecia – ", 12 },
				{ "But I can't – ", 12 }
			};
			break;

		case 12:
			toContent = "Hush up and wash up, hon. I'm not leaving you alone out there tonight.";
			AllowContinue();
			break;

		case 13:
			DoneTalking();
			Advance (14);
			break;

		case 14:
			toContent = "Go on, get yourself situated.";
			GetComponent<NPCMovement>().goalPosition = new Vector3 (-20, 0, 0);
			break;


			// SPECIAL ADDITIONS BELOW

			// give Frieda doubt about family
		case 24:
			GameObject.Find ("Frieda").GetComponent<NPCInventory>().inventory.Add ("Doubt about player's family");
			Advance (3);
			break;

			// player lies
		case 25:
			toContent = "Damnation. I wish I could help. Must be a hell of a readjustment. What were you in for, if you don't mind my asking?";
			Inventory.inventory.Add ("Lied about crime");
			Advance (26);
			break;

			// player's crime
		case 26:
			toContent = "Damnation. I wish I could help. Must be a hell of a readjustment. What were you in for, if you don't mind my asking?";
			AllowPlayerLines();
			playerLines = new Dictionary<string, int>() {
				{ "[Go back]", 3 },
				{ "...tax fraud.", 4 },
				{ "...drugs.", 5 },
				{ "...well, a son-of-a-bitch hurt my family. I lost my head.", 6 }
			};
			break;



		};

		if (!showConversation)
			showPlayerLine = false;

		content = toContent;
	}
	


	
}
