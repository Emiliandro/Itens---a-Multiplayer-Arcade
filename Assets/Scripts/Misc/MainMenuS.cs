using UnityEngine;
using System.Collections;

public class MainMenuS : MonoBehaviour {

	[SerializeField]private GameObject[] items;
	[SerializeField]private string[] cenas;
	private int count;
    public float DH = 0f;
	void Awake ()
	{

		count = 0;
	}

	void Update () {
        DH = Input.GetAxis("DirecionalH");
        if (count == 0)
		{
			items[0].transform.localScale = new Vector3(3f, 3f, 3f);
			items[1].transform.localScale = new Vector3(1.4f, 1.4f, 1f);
			if (DH == 1)
			{
				count = 1; 
			}
			if (Input.GetKey(KeyCode.Joystick1Button0))
			{
				Application.LoadLevel(cenas[0]);
			}
		}
		else {
			items[1].transform.localScale = new Vector3(3f, 3f, 3f);
			items[0].transform.localScale = new Vector3(1.4f, 1.4f, 1f);

			if (DH == -1){
				count = 0;
			}
			if (Input.GetKey(KeyCode.Joystick1Button0))
            {
				Application.LoadLevel(cenas[1]);
			}
		}


	}

}
