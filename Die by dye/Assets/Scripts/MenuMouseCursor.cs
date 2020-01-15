using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMouseCursor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.visible = false; //Defult cursor not viseble
	}

	// Update is called once per frame
	void Update () {
		Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Stores the cursors position
		transform.position = cursorPos;
	}
}
