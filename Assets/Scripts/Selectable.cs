using UnityEngine;

public abstract class Selectable : MonoBehaviour {

    protected Collider2D myCollider;
    protected bool isSelected;
    protected SpriteRenderer myRenderer;
    protected GameController gameController;
    protected Sprite[] sprites;

    // Use this for initialization
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        isSelected = false;
        myRenderer = GetComponent<SpriteRenderer>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    protected void becomeSelected()
    {
        isSelected = true;
        myRenderer.sprite = sprites[1];
        gameController.UpdateCurrentlySelected(this);
    }

    public virtual void BecomeDeselected()
    {
        isSelected = false;
        myRenderer.sprite = sprites[0];
    }
}
