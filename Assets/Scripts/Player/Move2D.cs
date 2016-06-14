using UnityEngine;
using System.Collections;

public class Move2D : MonoBehaviour {
    public float Speed = 0f;
    private float movex = 0f;
    private float movey = 0f;
    private float movex2 = 0f;
    private float movey2 = 0f;
    public Rigidbody2D source;
    public Rigidbody2D source2;
    // Update is called once per frame
    void FixedUpdate()
    {
        movex = Input.GetAxis("JoystickH1");
        movey = Input.GetAxis("JoystickV1");
        movex2 = Input.GetAxis("JoystickH2");
        movey2 = Input.GetAxis("JoystickV2");
        source.velocity = new Vector2(movex * Speed, movey * Speed);
        source2.velocity = new Vector2(movex2 * Speed, movey2 * Speed);
    }
}
