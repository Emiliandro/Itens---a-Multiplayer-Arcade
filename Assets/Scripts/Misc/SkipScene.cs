using UnityEngine;
using System.Collections;

public class SkipScene : MonoBehaviour {
	public string cena;
	void Update () {
		if (Input.anyKeyDown) Application.LoadLevel(cena);
	}
}
