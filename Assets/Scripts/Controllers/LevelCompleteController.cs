using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteController : LandingScreen {

    public Text CompleteText;
    public Text ScoreText;
    public Button RetryButton;
    public Button MainMenuButton;

	// Use this for initialization
	void Start () {

        ScaleAndPositionRectTransform(CompleteText.GetComponent<RectTransform>(), 0.1f, 0.75f, 0.3f);
        ScaleAndPositionRectTransform(ScoreText.GetComponent<RectTransform>(), 0.08f, 0.8f, 0.2f);
        ScoreText.text = "Score: " + GlobalData.PlayerScore;
        ScaleAndPositionRectTransform(RetryButton.GetComponent<RectTransform>(), buttonHeightScale, buttonWidthScale, 0);
        ScaleAndPositionRectTransform(MainMenuButton.GetComponent<RectTransform>(), buttonHeightScale, buttonWidthScale, -0.25f);

    }
	
}
