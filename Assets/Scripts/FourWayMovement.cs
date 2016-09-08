using UnityEngine;
using System.Collections;

public class FourWayMovement : MonoBehaviour {

    public float Speed = 0f;
    private float movex = 0f;
    private float movey = 0f;
    private float movex2 = 0f;
    private float movey2 = 0f;
    public Rigidbody2D source;
    //public Animator anim1;

    // Update is called once per frame
    void FixedUpdate()
    {
        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");
        source.velocity = new Vector2(movex * Speed, movey * Speed);

        //anim1.SetFloat("Horizontal", movex);
        //anim1.SetFloat("Vertical", movey);

    }
}
