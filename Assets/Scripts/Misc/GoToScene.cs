using UnityEngine;
using System.Collections;

public class GoToScene : MonoBehaviour { [SerializeField]private string scene; public void GoScene () { Application.LoadLevel (scene);} }
