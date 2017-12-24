using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code from https://forum.unity.com/threads/fading-in-out-gui-text-with-c-solved.380822/

public class NotificationText : MonoBehaviour {

    public TextMesh i;
    private const float fadeSpeed = 0.25f;
    private const float waitTime = 0.5f;

    void Start()
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
    }

    public void SetText(string text)
    {
        i.text = text;
    }

    public IEnumerator DisplayNotification()
    {
        //Fade in
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / fadeSpeed));
            yield return null;
        }
        //hold it
        yield return new WaitForSeconds(waitTime);

        //Fade out
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / fadeSpeed));
            yield return null;
        }
    }
}
