using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PanelControllers : MonoBehaviour
{

    //chamar o enumerador
    public GameObject[] scenes;

    // Use this for initialization
    void Start()
    {
            Time.timeScale = 0;
            scenes[1].SetActive(false);
            scenes[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (scenes[0].activeSelf) { 
        if (Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.LeftControl))
            {
                Time.timeScale = 1;
                scenes[0].SetActive(false);
                scenes[1].SetActive(true);
            }
        }

        else if (scenes[2].activeSelf) {
            if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick2Button1) || Input.GetKeyDown(KeyCode.LeftControl)) {
                SceneManager.LoadScene(Application.loadedLevel);

            }else if (Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Joystick2Button7) || Input.GetKeyDown(KeyCode.End))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
