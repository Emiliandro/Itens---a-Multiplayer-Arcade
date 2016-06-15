using UnityEngine;
using System.Collections;

public class SetBackgroundSprit : MonoBehaviour {

    public Sprite[] cavernas;
    private int Count;
    public GameObject bg;
    public Camera _camera;
    public Camera _camera2;

    public Color[] cores;
    // Use this for initialization
	void Start () {
        Count = Random.Range(0, cavernas.Length);

        bg.GetComponent<SpriteRenderer>().sprite = cavernas[Count];
        _camera.backgroundColor = Color.Lerp(cores[Count], cores[Count], 1f);
        _camera2.backgroundColor = Color.Lerp(cores[Count], cores[Count], 1f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
