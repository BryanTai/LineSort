using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selectable : MonoBehaviour {

    protected Collider2D myCollider;
    protected bool isSelected;
    protected SpriteRenderer myRenderer;

    // Use this for initialization
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        isSelected = false;
        myRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void becomeSelected(Sprite[] sprites)
    {
        isSelected = true;
        myRenderer.sprite = sprites[1];
    }

    protected void becomeUnselected(Sprite[] sprites)
    {
        isSelected = false;
        myRenderer.sprite = sprites[0];
    }
}
