using UnityEngine;
using System.Collections;

public class Move2D : MonoBehaviour {

    public float Speed = 0f;
    private float movex = 0f;
    private float movey = 0f;
    public Rigidbody2D source;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");
        source.velocity = new Vector2(movex * Speed, movey * Speed);
    }
}
