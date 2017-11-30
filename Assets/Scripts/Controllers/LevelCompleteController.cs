using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteController : MonoBehaviour {

    public Text CompleteText;
    public Text ScoreText;
    public Button RetryButton;
    public Button MainMenuButton;

	// Use this for initialization
	void Start () {
        float buttonHeight = Screen.height * 0.1f;
        float buttonWidth = Screen.width * 0.75f;


        RectTransform CompleteRect = CompleteText.GetComponent<RectTransform>();
        CompleteRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height * 0.1f);
        CompleteRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width * 0.75f);
        CompleteRect.anchoredPosition = new Vector2(0, Screen.height * 0.3f);

        RectTransform ScoreRect = ScoreText.GetComponent<RectTransform>();
        ScoreRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height * 0.08f);
        ScoreRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width * 0.8f);
        ScoreRect.anchoredPosition = new Vector2(0, Screen.height * 0.2f);
        ScoreText.text = "Score: " + GlobalData.PlayerScore;

        RectTransform RetryRect = RetryButton.GetComponent<RectTransform>();
        RetryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonHeight);
        RetryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, buttonWidth);
        RetryRect.anchoredPosition = new Vector2(0, 0);

        RectTransform MainRect = MainMenuButton.GetComponent<RectTransform>();
        MainRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonHeight);
        MainRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, buttonWidth);
        MainRect.anchoredPosition = new Vector2(0, Screen.height * -0.25f); //divide by 2

    }

    void setTrsansformToScreenResolution()
    {
        //TODO
    }
	
}
