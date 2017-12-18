using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandingScreen : MonoBehaviour {

    protected float buttonHeightScale = 0.1f;
    protected float buttonWidthScale = 0.75f;

	protected void ScaleAndPositionRectTransform(RectTransform Rect, float verticalScale, float horizontalScale, float verticalPosition)
    {
        Rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height * verticalScale);
        Rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width * horizontalScale);
        Rect.anchoredPosition = new Vector2(0, Screen.height * verticalPosition);
    }
}
