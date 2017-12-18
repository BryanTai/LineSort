using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuController : LandingScreen {

    public Button StartGameButton;
    public Button OptionsButton;
    public Image OptionsMenu;

	// Use this for initialization
	void Start () {
        SaveAndExitOptionsMenu();

        ScaleAndPositionRectTransform(StartGameButton.GetComponent<RectTransform>(), buttonHeightScale, buttonWidthScale, 0);
        ScaleAndPositionRectTransform(OptionsButton.GetComponent<RectTransform>(), buttonHeightScale, buttonWidthScale, -0.2f);
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
