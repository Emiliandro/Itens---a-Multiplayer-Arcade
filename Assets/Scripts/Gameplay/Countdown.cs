using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    public float total = 20f;
    public Text texto;
    public Text _text;
    public GameObject gameover;
	// Use this for initialization
	void Start () {
        total = 20f;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (total < 0)
        {
            _text.text = "game over!";
            gameover.SetActive(true);
            Time.timeScale = 0;
        }

        total -= Time.deltaTime;
        texto.text = ( Mathf.RoundToInt(total)).ToString();
    }
}
