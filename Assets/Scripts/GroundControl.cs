using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour
{

    public Vector2 initialPos;
    private GameObject ball;
    private GameObject paddle;
    private Rigidbody2D ballRb;
    private GameObject ballLoseSound;

    public PaddleController paddleController;
    public GameManager gameManager;


    void Start()
    {
        //ball = GameObject.FindGameObjectWithTag("Ball");
        //paddle = GameObject.FindGameObjectWithTag("Player");
        //ballRb = ball.GetComponent<Rigidbody2D>();
        //initialPos = ball.transform.position;
        ballLoseSound = GameObject.Find("BallLose");
    }

    //Si la pelota sale por abajo se reposiciona
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Ball")
        {
            //ball.transform.position = new Vector3 (paddle.transform.position.x, paddle.transform.position.y + 0.6f,paddle.transform.position.z);
            //ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //ballRb.isKinematic = true;
            
            //ball.GetComponent<Transform>().transform.parent = paddle.GetComponent<Transform>().transform;
            Destroy(other);
            paddleController.isBallDead = true;
            ballLoseSound.GetComponent<AudioSource>().Play();
            gameManager.LosingBall();
        }
    }
	
}
