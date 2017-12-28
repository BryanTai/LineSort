using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code from https://forum.unity.com/threads/fading-in-out-gui-text-with-c-solved.380822/

public class NotificationText : MonoBehaviour {

    public TextMesh NotificationTextMesh;
    private const float fadeSpeed = 0.25f;
    private const float waitTime = 0.5f;

    void Start()
    {
        NotificationTextMesh.color = new Color(NotificationTextMesh.color.r, NotificationTextMesh.color.g, NotificationTextMesh.color.b, 0);
    }

    public void SetText(string text)
    {
        NotificationTextMesh.text = text;
    }

    public void SetColor(Color color)
    {
        NotificationTextMesh.color = color;
    }

    public void FlashNotification()
    {
        StartCoroutine(DisplayNotification());
    }

    public void FlashNotification(string text, Color color)
    {
        SetText(text);
        SetColor(color);
        StartCoroutine(DisplayNotification());
    }

    public IEnumerator DisplayNotification()
    {
        //Fade in
        NotificationTextMesh.color = new Color(NotificationTextMesh.color.r, NotificationTextMesh.color.g, NotificationTextMesh.color.b, 0);
        while (NotificationTextMesh.color.a < 1.0f)
        {
            NotificationTextMesh.color = new Color(NotificationTextMesh.color.r, NotificationTextMesh.color.g, NotificationTextMesh.color.b, NotificationTextMesh.color.a + (Time.deltaTime / fadeSpeed));
            yield return null;
        }
        //hold it
        yield return new WaitForSeconds(waitTime);

        //Fade out
        NotificationTextMesh.color = new Color(NotificationTextMesh.color.r, NotificationTextMesh.color.g, NotificationTextMesh.color.b, 1);
        while (NotificationTextMesh.color.a > 0.0f)
        {
            NotificationTextMesh.color = new Color(NotificationTextMesh.color.r, NotificationTextMesh.color.g, NotificationTextMesh.color.b, NotificationTextMesh.color.a - (Time.deltaTime / fadeSpeed));
            yield return null;
        }
    }
}
