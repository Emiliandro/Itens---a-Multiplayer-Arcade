using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    [Header("Movimento")]
    public float velocidade;
    public float espaco;
    public float tempo;
    [Header("Alvo")]
    public GameObject alvo;

    // Use this for initialization
    void Start()
    {
        velocidade = espaco / tempo;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != alvo.transform.position) StartCoroutine(Perseguir());
    }

    IEnumerator Perseguir()
    {
        transform.position = Vector2.MoveTowards(transform.position, alvo.transform.position, velocidade);
        yield return new WaitForSeconds(tempo);
    }
}
