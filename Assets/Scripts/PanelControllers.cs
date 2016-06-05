using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PanelControllers : MonoBehaviour
{
    public enum cenas
    {
        end = 1,
        start = 2
    };

    //chamar o enumerador
    public cenas qual;
    public GameObject[] scenes;
    // Use this for initialization
    void Start()
    {
        if (qual == cenas.start)
        {
            Time.timeScale = 0;
            scenes[1].SetActive(false);
            scenes[2].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (qual == cenas.start)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                scenes[0].SetActive(false);
                scenes[1].SetActive(true);
            }
            if (qual == cenas.end)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("Multiplayer");
                }
            }
        }
    }
}
