using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {
    public Text ScoreText;
    public int Score { get; private set;}

    // Use this for initialization
    void Start()
    {
        Score = 0;

        RectTransform scoreRect = ScoreText.GetComponent<RectTransform>();
        float scoreX = Screen.width * -0.4f;
        float scoreY = Screen.height * 0.45f;
        scoreRect.anchoredPosition = new Vector2(scoreX, scoreY); //Top left corner
    }
	
	public void UpdateScore(int newScore)
    {
        Score = newScore;
        updateText();
    }
    public void IncreaseScore(int increment)
    {
        Score += increment;
        updateText();
    }

    private void updateText()
    {
        ScoreText.text = "Score: " + Score;
    }
}
