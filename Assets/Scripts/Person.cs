using System;
using UnityEngine;

public enum PersonState { Waiting, InLine }
public class Person : Selectable {

    public string Name { get; private set; }
    public int LocationIndex { get; set; }
    public PersonState State {get; private set;}
    private SpriteRenderer personRenderer;
    private MeshRenderer textRenderer;
    private TextMesh textMesh;

    private Rigidbody2D personRigidBody;

    void Awake()
    {
        personRenderer = GetComponent<SpriteRenderer>();

        Transform childText = gameObject.transform.GetChild(0);
        textMesh = childText.GetComponent<TextMesh>();
        textRenderer = childText.GetComponent<MeshRenderer>();

        textRenderer.sortingLayerName = "Names";
        textRenderer.sortingOrder = 1;
        State = PersonState.Waiting;

        personRigidBody = GetComponent<Rigidbody2D>();

        //TODO show all text for now
        //FIND THE OTHER ENABLED
        textRenderer.enabled = true;
    }

    void OnMouseDown()
    {
        becomeSelected();
        //TODO Make the name text BIGGER
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
        //TODO make the name text back to Default size
        personRenderer.sortingOrder = 0;
    }

    public void PlaceInLine(Vector2 linePosition)
    {
        State = PersonState.InLine;
        gameObject.layer = 2; //Ignore Raycast Layer
        TeleportToPoint(linePosition);
        textRenderer.enabled = false;
    }

    public void TeleportToPoint(Vector2 point)
    {
        personRigidBody.MovePosition(point);
    }
}
