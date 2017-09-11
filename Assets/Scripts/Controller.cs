using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    Selectable currentlySelected;
    Selectable previouslySelected;

    public List<GameObject> AllSelectableObjects;

	// Use this for initialization
	void Start () {
        AllSelectableObjects = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
