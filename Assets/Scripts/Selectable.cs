using UnityEngine;

public abstract class Selectable : MonoBehaviour {

    protected Collider2D myCollider;
    protected bool isSelected;
    protected SpriteRenderer myRenderer;
    protected GameController gameController;
    protected Sprite[] sprites;
    const int IDLE_INDEX = 0;
    const int SELECTED_INDEX = 1;

    // Use this for initialization
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        isSelected = false;
        myRenderer = GetComponent<SpriteRenderer>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        myRenderer.sprite = sprites[IDLE_INDEX];
    }

    protected void becomeSelected()
    {
        isSelected = true;
        myRenderer.sprite = sprites[SELECTED_INDEX];
        gameController.UpdateCurrentlySelected(this);
    }

    public virtual void BecomeDeselected()
    {
        isSelected = false;
        myRenderer.sprite = sprites[IDLE_INDEX];
    }

    public void SetSprites(Sprite[] sprites)
    {
        this.sprites = sprites;
    }
}
