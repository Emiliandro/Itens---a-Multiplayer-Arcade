using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public string cena;
    public float tempo;

	void Start ()
    {
        StartCoroutine(mudaCena());
	}

    IEnumerator mudaCena() {
        yield return new WaitForSeconds(tempo);
        SceneManager.LoadScene(cena);

    }
}
