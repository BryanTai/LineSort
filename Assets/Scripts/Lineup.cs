using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lineup : Selectable {

    void Awake()
    {
        sprites = Resources.LoadAll<Sprite>("lineup_sheet");
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked Lineup!");
        becomeSelected();
    }
}
