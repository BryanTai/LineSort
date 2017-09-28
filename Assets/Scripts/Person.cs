using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : Selectable {

    public string Name { get; private set; }
    private MeshRenderer textRenderer;
    private TextMesh textMesh;

    void Awake()
    {
        sprites = Resources.LoadAll<Sprite>("person_sheet");
        Transform childText = gameObject.transform.GetChild(0);
        textMesh = childText.GetComponent<TextMesh>();
        textRenderer = childText.GetComponent<MeshRenderer>();
    }

    void OnMouseDown()
    {
        becomeSelected();
        textRenderer.enabled = true;
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
    }
}
