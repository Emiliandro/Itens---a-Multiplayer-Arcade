using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCollider1 : MonoBehaviour {
    public GameObject gameover;
    public Text _text;
    public Image _camera;
    public Color[] cores;
    public GameObject player;
    public static int num1, num2, mortes;

    void Start()
    {
        num1 = 0;
        num2 = 0;
        mortes = 2;
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Finish") {
            if (mortes < 2)
            {
                _camera.color = cores[1];
                _text.text = "game over!";
                gameover.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                mortes--;
                this.gameObject.SetActive(false);
            }

            
        }
        if (other.tag == "items") {
            if (num1 == 3 || num2 == 3)
            {
                _camera.color = cores[0];

                _text.text = this.name + " ganhou!";
                gameover.SetActive(true);
                Time.timeScale = 0;
            }
            else {
                if (this.name == "Player 1") num1++;
                else if (this.name == "Player 2") num2++;
                other.gameObject.SetActive(false);
                TotensSelect.instance.CriarTotem();
                }            
        }
    }
}
