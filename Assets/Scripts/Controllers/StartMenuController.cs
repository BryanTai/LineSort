using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour {

    public Button StartGameButton;
    public Button OptionsButton;
    public Image OptionsMenu;

	// Use this for initialization
	void Start () {
        SaveAndExitOptionsMenu();
        float buttonHeight = Screen.height * 0.1f;
        float buttonWidth = Screen.width * 0.5f;
        StartGameButton.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonHeight);
        StartGameButton.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, buttonWidth);

        OptionsButton.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, buttonHeight);
        OptionsButton.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, buttonWidth);

        //TODO set Options Menu image size to scale screen resolution
    }

    public void NoSaveAndExitOptionsMenu()
    {
        OptionsMenu.gameObject.SetActive(false);
    }

    //TODO Cache temporary changes in this controller object and then pass them to the Global object when save is hit
    public void SaveAndExitOptionsMenu()
    {
        OptionsMenu.gameObject.SetActive(false);
    }

    public void OpenOptionsMenu()
    {
        OptionsMenu.gameObject.SetActive(true);
    }

}
