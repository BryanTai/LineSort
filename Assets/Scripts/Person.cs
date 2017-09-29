using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : Selectable {

    public string Name { get; private set; }
    private SpriteRenderer personRenderer;
    private MeshRenderer textRenderer;
    private TextMesh textMesh;

    private Rigidbody2D personRigidBody;
    private bool isWalking;
    private float destinationX;
    private float destinationY;
    private float walkSpeed;

    void Awake()
    {
        sprites = Resources.LoadAll<Sprite>("person_sheet");

        personRenderer = GetComponent<SpriteRenderer>();

        Transform childText = gameObject.transform.GetChild(0);
        textMesh = childText.GetComponent<TextMesh>();
        textRenderer = childText.GetComponent<MeshRenderer>();

        textRenderer.sortingLayerName = "Names";
        textRenderer.sortingOrder = 1;
        isWalking = false;
        walkSpeed = 1.0f; //TODO Adjust this

        personRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isWalking)
        {
            Vector2 destination = new Vector2(destinationX, destinationY);
            personRigidBody.MovePosition(destination);
            isWalking = false;
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked Person: " + Name);
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

    public void WalkToPoint(float x, float y)
    {
        isWalking = true;
        destinationX = x;
        destinationY = y;
    }
}
