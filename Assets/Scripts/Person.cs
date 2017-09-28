using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : Selectable {

    public string Name { get; private set; }
    private SpriteRenderer personRenderer;
    private MeshRenderer textRenderer;
    private TextMesh textMesh;

    void Awake()
    {
        sprites = Resources.LoadAll<Sprite>("person_sheet");

        personRenderer = GetComponent<SpriteRenderer>();

        Transform childText = gameObject.transform.GetChild(0);
        textMesh = childText.GetComponent<TextMesh>();
        textRenderer = childText.GetComponent<MeshRenderer>();

        textRenderer.sortingLayerName = "Names";
        textRenderer.sortingOrder = 1;
    }

    void OnMouseDown()
    {
        becomeSelected();
        textRenderer.enabled = true;
        personRenderer.sortingOrder = 2; //Move it to the front
    }

    public void SetName(string name)
    {
        this.Name = name;
        textMesh.text = this.Name;
    }

    public override void BecomeDeselected()
    {
        base.BecomeDeselected();
        textRenderer.enabled = false;
        personRenderer.sortingOrder = 0;
    }
}
