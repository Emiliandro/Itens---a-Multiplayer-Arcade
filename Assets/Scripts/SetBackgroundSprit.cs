using UnityEngine;
using System.Collections;

public class SetBackgroundSprit : MonoBehaviour {

    public Sprite[] cavernas;
    private int Count;
    public GameObject bg;
    // Use this for initialization
	void Start () {
        Count = Random.Range(0, cavernas.Length);

        bg.GetComponent<SpriteRenderer>().sprite = cavernas[Count];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
