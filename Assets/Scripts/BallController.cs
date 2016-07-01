using UnityEngine;
using UnityEngine.Networking;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class BallController : NetworkBehaviour {

    [SerializeField]
    private float ballSpeedX;

    [SerializeField]
    private float ballSpeedY;

    [SerializeField]
    private float startDelay = 3f;

   
    private Rigidbody2D rgbd;
	
	void Awake () {

        rgbd = GetComponent<Rigidbody2D>();
	}

    public override void OnStartServer()
    {
        //StartCoroutine(WaitBeforeThrust());
        ThrustBall();
    }

  

    void ThrustBall()
    {
        float randomNumber = Random.Range(0, 2);
        if (randomNumber <= 0.5)
        {
            //thrust ball towards right
            rgbd.AddForce(new Vector2(ballSpeedX, ballSpeedY));
        }
        else
        {
            //thrust ball towards left
            rgbd.AddForce(new Vector2(-ballSpeedX, -ballSpeedY));
        }
     
    }

    /* IEnumerator WaitBeforeThrust()
    {
        // wait for some time before thrusting the ball
        yield return new WaitForSeconds(startDelay);
    }*/

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            rgbd.velocity = rgbd.velocity * 1.05f;
        }
            
    
    }
}
