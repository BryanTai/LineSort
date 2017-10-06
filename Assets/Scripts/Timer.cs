using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Text TimerText;

    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0"); //set to "f2" for 2 decimal places

        TimerText.text = minutes + ":" + seconds;
        //TODO nicer formatting (e.g. add a 0 if the seconds is < 10)
	}
}
