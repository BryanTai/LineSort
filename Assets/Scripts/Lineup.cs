using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lineup : Selectable {

    void OnMouseDown()
    {
        Debug.Log("Clicked Lineup!");
        isSelected = true;
    }
}
