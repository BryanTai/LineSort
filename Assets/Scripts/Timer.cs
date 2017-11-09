using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Text TimerText;

    private float startTime;
    public float timeLeftSeconds;
    private bool gameOver = false;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        timeLeftSeconds = 120; //TODO set value some other way

        RectTransform timerRect = TimerText.GetComponent<RectTransform>();
        float timerX = 0;//Screen.width * -0.4f;
        float timerY = Screen.height * 0.45f;
        timerRect.anchoredPosition = new Vector2(timerX, timerY); //Top middle

        Debug.Log("TIME WIDTH : " + timerX + " TIME HEIGHT : " + timerY);
    }
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            return;
        }

        timeLeftSeconds -= Time.deltaTime;
        float timeToPrint = Mathf.Round(timeLeftSeconds);
        string minutes = ((int)timeToPrint / 60).ToString();
        string seconds = (timeToPrint % 60).ToString("f0"); //set to "f2" for 2 decimal places

        if(timeToPrint % 60 < 10)
        {
            seconds = "0" + seconds;
        }

        TimerText.text = minutes + ":" + seconds;

        if (timeLeftSeconds < 0)
        {
            Debug.Log("GAME OVER!!!");
            //TODO signal the GameController....or incorperate this code into GameController
            //... or just leave it be?
            gameOver = true;

            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelComplete");
        }
    }
}
