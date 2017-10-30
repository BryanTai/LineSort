using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour {

    public Button StartGameButton;

	// Use this for initialization
	void Start () {
        float buttonHeight = Screen.height * 0.1f;
        float buttonWidth = Screen.width * 0.5f;
        StartGameButton.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonHeight);
        StartGameButton.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, buttonWidth);

    }

}
