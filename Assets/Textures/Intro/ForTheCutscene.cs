using UnityEngine;
using System.Collections;

public class ForTheCutscene : MonoBehaviour {

    public float time;
    public string scene;
    // Use this for initialization
    void Update()
    {
        Invoke("changeScene", time);
    }

    // Update is called once per frame
    void changeScene()
    {
        Application.LoadLevel(scene);
    }
}
