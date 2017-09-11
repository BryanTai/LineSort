using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selectable : MonoBehaviour {

    protected Collider2D myCollider;
    protected bool isSelected;

    // Use this for initialization
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        isSelected = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
