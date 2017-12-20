using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuController : LandingScreen {
    //Start Menu objects
    public Button StartGameButton;
    public Button OptionsMenuButton;
    //Options Menu objects
    public Image OptionsMenu;
    public Button EndGameButton; //TODO just for testing
    public Button SaveAndExitButton;
    public Button CloseMenuButton;

	void Start () {
        SaveAndExitOptionsMenu();

        ScaleAndPositionRectTransform(StartGameButton.GetComponent<RectTransform>(), buttonHeightScale, buttonWidthScale, 0);
        ScaleAndPositionRectTransform(OptionsMenuButton.GetComponent<RectTransform>(), buttonHeightScale, buttonWidthScale, -0.2f);

        ScaleAndPositionRectTransform(OptionsMenu.GetComponent<RectTransform>(), 1, 1, 0);
        ScaleAndPositionRectTransform(SaveAndExitButton.GetComponent<RectTransform>(), buttonHeightScale, buttonWidthScale, -0.2f);
        ScaleAndPositionRectTransform(EndGameButton.GetComponent<RectTransform>(), buttonHeightScale, buttonWidthScale, -0.4f);
        ScaleAndPositionRectTransformForSquares(CloseMenuButton.GetComponent<RectTransform>(),0.1f, 0.4f, 0.4f);
        //TODO FIX AFTER REFACTOR
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
