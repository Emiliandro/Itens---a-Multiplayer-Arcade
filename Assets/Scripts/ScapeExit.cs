﻿using UnityEngine;
using System.Collections;

public class ScapeExit : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape))
			Application.Quit ();
	}

    public void Close() {
        Application.Quit();

    }
}
