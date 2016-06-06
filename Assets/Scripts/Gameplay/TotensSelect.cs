using UnityEngine;
using System.Collections;

public class TotensSelect : MonoBehaviour {

    public GameObject[] posicoes;
    public int Count;
    public int oldCount;
	// Use this for initialization
	void Start () {
        Count = Random.Range(0, posicoes.Length);
        oldCount = Count;
        posicoes[Count].SetActive(true);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //InvokeRepeating("ChangePos", 5f , 0f);
	
	}

    void ChangePos()
    {
        StartCoroutine(positionsChanger());
    }

    IEnumerator positionsChanger()
    {
        posicoes[oldCount].SetActive(false);
        Count = Random.Range(0, posicoes.Length);
        oldCount = Count;
        posicoes[Count].SetActive(true);
        yield return new WaitForSeconds(4f);
    }
}
