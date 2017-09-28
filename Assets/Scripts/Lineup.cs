using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lineup : Selectable {

    public string Rule { get; set; }

    void Awake()
    {
        sprites = Resources.LoadAll<Sprite>("lineup_sheet");
    }

    void OnMouseDown()
    {
        becomeSelected();
    }
}
