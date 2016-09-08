using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour {

    public string cena;
    public float tempo;

    public IEnumerator mudaCena()
    {
        yield return new WaitForSeconds(tempo);
        SceneManager.LoadScene(cena);

    }
}
