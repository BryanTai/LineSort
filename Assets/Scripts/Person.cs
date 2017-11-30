using UnityEngine;

public class Person : Selectable {

    public string Name { get; private set; }
    public int LocationIndex { get; set; }
    private SpriteRenderer personRenderer;
    private MeshRenderer textRenderer;
    private TextMesh textMesh;

    private Rigidbody2D personRigidBody;
    private bool isWalking;
    private float destinationX;
    private float destinationY;

    void Awake()
    {
        personRenderer = GetComponent<SpriteRenderer>();

        Transform childText = gameObject.transform.GetChild(0);
        textMesh = childText.GetComponent<TextMesh>();
        textRenderer = childText.GetComponent<MeshRenderer>();

        textRenderer.sortingLayerName = "Names";
        textRenderer.sortingOrder = 1;
        isWalking = false;

        personRigidBody = GetComponent<Rigidbody2D>();

        //TODO show all text for now
        //FIND THE OTHER ENABLED
        textRenderer.enabled = true;
    }

    void Update()
    {
        if (isWalking)
        {
            //TODO currently this just teleports, make it move smoothly
            Vector2 destination = new Vector2(destinationX, destinationY);
            personRigidBody.MovePosition(destination);
            isWalking = false;
        }
    }

    void OnMouseDown()
    {
        //Debug.Log("Clicked Person: " + Name);
        becomeSelected();
        //TODO Make the name text BIGGER
        //textRenderer.enabled = true;
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
        //textRenderer.enabled = false;
        personRenderer.sortingOrder = 0;
    }

    public void WalkToPoint(Vector2 point)
    {
        isWalking = true;
        destinationX = point.x;
        destinationY = point.y;
    }

    public void TeleportToPoint(Vector2 point)
    {
        isWalking = false;
        personRigidBody.MovePosition(point);
    }
}
