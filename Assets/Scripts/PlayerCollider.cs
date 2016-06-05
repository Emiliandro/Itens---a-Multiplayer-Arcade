using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {
    public GameObject gameover;

    public GameObject player;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Finish") {
            gameover.SetActive(true);
            Time.timeScale = 0;

            Destroy(player);
        }
    }
}
