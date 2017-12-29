using System.Collections;
using UnityEngine;
//Code from https://forum.unity.com/threads/fading-in-out-gui-text-with-c-solved.380822/

public class NotificationGenerator : MonoBehaviour {

    public GameObject NotificationPrefab;
    private const float FADE_SPEED = 4f;
    private const float WAIT_TIME = 0.5f;
    private const float LINEUP_OFFSET = 1.6f;


    public void FlashNotification(string text, Color color, GameObject anchor)
    {
        StartCoroutine(DisplayNotification(text, color, anchor));
    }

    //TODO might need this for other GameObjects, like Persons
    private float applyOffset()
    {
        return LINEUP_OFFSET;
    }

    IEnumerator DisplayNotification(string text, Color color, GameObject anchor)
    {
        //Create new invisible
        Vector3 newPosition = anchor.transform.position;
        newPosition.y += applyOffset();
        GameObject newNotification = Instantiate(NotificationPrefab, newPosition, Quaternion.identity);

        TextMesh NotificationTextMesh = newNotification.GetComponent<TextMesh>();
        NotificationTextMesh.color = new Color(color.r, color.g, color.b, 0);
        NotificationTextMesh.text = text;

        //Fade in
        NotificationTextMesh.color = new Color(NotificationTextMesh.color.r, NotificationTextMesh.color.g, NotificationTextMesh.color.b, 0);
        while (NotificationTextMesh.color.a < 1.0f)
        {
            NotificationTextMesh.color = new Color(NotificationTextMesh.color.r, NotificationTextMesh.color.g, NotificationTextMesh.color.b, NotificationTextMesh.color.a + (Time.deltaTime * FADE_SPEED));
            yield return null;
        }
        //hold it
        yield return new WaitForSeconds(WAIT_TIME);

        //Fade out
        NotificationTextMesh.color = new Color(NotificationTextMesh.color.r, NotificationTextMesh.color.g, NotificationTextMesh.color.b, 1);
        while (NotificationTextMesh.color.a > 0.0f)
        {
            NotificationTextMesh.color = new Color(NotificationTextMesh.color.r, NotificationTextMesh.color.g, NotificationTextMesh.color.b, NotificationTextMesh.color.a - (Time.deltaTime * FADE_SPEED));
            yield return null;
        }

        Destroy(newNotification);
    }
}
