using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour {
    public GameObject gameover;
    public Text _text;
    public Image _camera;
    public Color[] cores;
    public GameObject player;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Finish") {
            _camera.color = cores[1];

            _text.text = "game over!";
            gameover.SetActive(true);
            Time.timeScale = 0;

            //Destroy(player);
        }
        if (other.tag == "items") {
            _camera.color = cores[0];

            _text.text = "Player 1 ganhou!";
            gameover.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
