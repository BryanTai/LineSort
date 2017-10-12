using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {
    public Text ScoreText;
    public int Score { get; private set;}

	// Use this for initialization
	void Start () {
        Score = 0;
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
