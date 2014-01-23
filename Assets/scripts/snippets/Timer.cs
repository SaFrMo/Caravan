using UnityEngine;
using System.Collections;

public class Timer {
	
	// START HERE
	public Timer (float dMinimumLength, float dMaximumLength, bool toLoop) {
		minimumTimerLength = dMinimumLength;
		maximumTimerLength = dMaximumLength;
		useRandomTimerLengths = true;
		loop = toLoop;
	}
	
	public Timer (float dFixedLength, bool toLoop) {
		fixedTimerLength = dFixedLength;
		useRandomTimerLengths = false;
		loop = toLoop;
	}
	
	public Timer (float dMinimumLength, float dMaximumLength, int timesToLoop) {
		minimumTimerLength = dMinimumLength;
		maximumTimerLength = dMaximumLength;
		useRandomTimerLengths = true;
		loop = true;
		loopXTimes = true;
		loopNumber = timesToLoop;
	}
	
	public Timer (float dFixedLength, int timesToLoop) {
		fixedTimerLength = dFixedLength;
		loop = true;
		useRandomTimerLengths = false;
		loopXTimes = true;
		loopNumber = timesToLoop;
	}
	
	//public bool useRandomTimerLengths = true;
	public bool loop = true;
	public bool loopXTimes = false;
	bool done = false;
	
	// for random timer lengths
	public float minimumTimerLength = 2f;
	public float maximumTimerLength = 5f;
	public bool useRandomTimerLengths = true;
	
	// for fixed timer length
	public float fixedTimerLength = 4f;
	
	// how many times to loop
	public int loopNumber = 5;
	int currentLoop = 1;
	
	// is the timer set?
	bool timerSet = false;
	
	// actual timer length
	float lastTrigger;
	float timerLength;
	
	// set or reset the timer
	void SetTimer () {
		lastTrigger = Time.realtimeSinceStartup;
		if (!useRandomTimerLengths) 
			timerLength = fixedTimerLength;
		else
			timerLength = Random.Range (minimumTimerLength, maximumTimerLength);
		
		timerSet = true;
	}
	
	
	// this is the method to call in Update()
	public bool RunTimer () {
		if (!done) {
			// set/reset timer
			if (!timerSet) {
				SetTimer();
				timerSet = true;
				return false;
			}
			if (Time.realtimeSinceStartup >= lastTrigger + timerLength) {
				
				// exits loop
				if (!loop) {
					done = true;
					//return false;
				}
				else if (loopXTimes) {
					if (currentLoop < loopNumber) {
						currentLoop++;
					}
					else {
						done = true;
						//return false;
					}
				}
				timerSet = false;
				return true;
			}
			else
				return false;
		}
		else 
			return false;
	}
}
