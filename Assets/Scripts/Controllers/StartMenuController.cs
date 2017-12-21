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
    public Text OptionsText;
    public Button EndGameButton; //TODO just for testing
    public Button SaveAndExitButton;
    public Button CloseMenuButton;
    public Text TimerSecondsText;
    public InputField TimerSecondsInput;
    public Text CreatePersonText;
    public InputField CreatePersonInput;

    void Start () {
        NoSaveAndExitOptionsMenu();

        ScaleAndPositionRectTransform(StartGameButton.GetComponent<RectTransform>(), buttonHeightScale, buttonWidthScale, 0);
        ScaleAndPositionRectTransform(OptionsMenuButton.GetComponent<RectTransform>(), buttonHeightScale, buttonWidthScale, -0.2f);

        ScaleAndPositionRectTransform(OptionsMenu.GetComponent<RectTransform>(), 1, 1, 0);
        ScaleAndPositionRectTransform(OptionsText.GetComponent<RectTransform>(), 0.1f, 0.75f, 0.4f);
        ScaleAndPositionRectTransform(SaveAndExitButton.GetComponent<RectTransform>(), buttonHeightScale, buttonWidthScale, -0.3f);
        ScaleAndPositionRectTransform(EndGameButton.GetComponent<RectTransform>(), buttonHeightScale, buttonWidthScale, -0.4f);
        ScaleAndPositionRectTransformForSquares(CloseMenuButton.GetComponent<RectTransform>(),0.1f, 0.4f, 0.4f);

        ScaleAndPositionRectTransform(TimerSecondsText.GetComponent<RectTransform>(), 0.05f, 0.5f, 0.25f);
        ScaleAndPositionRectTransform(TimerSecondsInput.GetComponent<RectTransform>(), 0.05f, 0.15f, 0.2f);
        TimerSecondsInput.text = GlobalData.TimerSeconds.ToString();

        ScaleAndPositionRectTransform(CreatePersonText.GetComponent<RectTransform>(), 0.05f, 0.5f, 0.15f);
        ScaleAndPositionRectTransform(CreatePersonInput.GetComponent<RectTransform>(), 0.05f, 0.15f, 0.1f);
        CreatePersonInput.text = GlobalData.CreatePersonRate.ToString();
    }

    public void NoSaveAndExitOptionsMenu()
    {
        OptionsMenu.gameObject.SetActive(false);
    }

    public void SaveAndExitOptionsMenu()
    {
        updateGlobalData();
        OptionsMenu.gameObject.SetActive(false);
        Debug.Log("Changes SAVED!");
    }

    public void OpenOptionsMenu()
    {
        OptionsMenu.gameObject.SetActive(true);
    }

    private void updateGlobalData()
    {
        GlobalData.TimerSeconds = int.Parse(TimerSecondsInput.text);
        GlobalData.CreatePersonRate = int.Parse(CreatePersonInput.text);
    }

}
