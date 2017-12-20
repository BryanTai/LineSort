using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandingScreen : MonoBehaviour {

    protected float buttonHeightScale = 0.1f;
    protected float buttonWidthScale = 0.75f;

	protected void ScaleAndPositionRectTransform(RectTransform Rect, float verticalScale, float horizontalScale, float yPos)
    {
        SetSizeAndPositionRectTransform(Rect, Screen.height * verticalScale, Screen.width * horizontalScale, 0, yPos);
    }

    protected void ScaleAndPositionRectTransformForSquares(RectTransform Rect, float horizontalScale, float xPos, float yPos)
    {
        float width = Screen.width * horizontalScale;
        SetSizeAndPositionRectTransform(Rect, width, width, xPos, yPos);
    }

    protected void SetSizeAndPositionRectTransform(RectTransform Rect, float height, float width, float xPos, float yPos)
    {
        Rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        Rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        Rect.anchoredPosition = new Vector2(Screen.width * xPos, Screen.height * yPos);
    }
}
