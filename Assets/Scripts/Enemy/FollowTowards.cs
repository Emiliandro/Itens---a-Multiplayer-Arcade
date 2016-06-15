using UnityEngine;
using System.Collections;

public class FollowTowards : MonoBehaviour
{
    private float speed = 0.02f;
    public GameObject[] Players;
    public GameObject Player;
    public Rigidbody2D Source;

	// Use this for initialization
	IEnumerator Following ()
    {
        Vector3 path = Vector3.MoveTowards(transform.position, Player.transform.position, speed);
        Source.MovePosition(path);
        yield return new WaitForSeconds(4);
	}

    IEnumerator SpeedDecreaser()
    {

        speed = 0.04f ;
        yield return new WaitForSeconds(4);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        InvokeRepeating("callFollow", 1f, 1f);
	}

    void callFollow()
    {
        StartCoroutine(Following());
    }

    void OnTrigger2DEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(SpeedDecreaser());
        }
    }

    void OnTrigger2DExit(Collider other)
    {
        if (other.tag == "Player")
        {
            speed = 0.02f;
        }
    }

    void Start()
    {
        Player = Players[Random.Range(0, Players.Length)];

    }

}
