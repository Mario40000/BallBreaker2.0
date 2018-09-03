using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public float force = 10.0f;
    public float speed = 10.0f;
    public float ballSpeed = 10.0f;
    public GameObject ball;

    private Rigidbody2D rb;
    private Rigidbody2D ballRb;
    private GameObject bounceSound;

    public bool isBallDead = true;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ballRb = ball.GetComponent<Rigidbody2D>();
        bounceSound = GameObject.Find("BounceSound");
    }

    void Update()
    {
        if (Input.GetButton("Jump") && isBallDead)
        {
            launchBall();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Movimiento por fuerza y velocidad de la raqueta
        float h = Input.GetAxis("Horizontal");

        Vector2 vector = new Vector2(h, 0);

        rb.AddForce(vector * force * Time.deltaTime);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -speed, speed), 0);

        //Impedimos que se salga de los limites
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -5.79f, 5.79f), transform.position.y);
    }

    //Metodo para lanzar la pelota al inicio
    void launchBall()
    {
        isBallDead = false;
        ballRb.isKinematic = false;
        ballRb.AddForce(new Vector2(0, ballSpeed));
        ball.GetComponent<Transform>().transform.parent = null;
    }

    //Metodo para que la bola suene al golpear la raqueta
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ball")
        {
            bounceSound.GetComponent<AudioSource>().Play();
        }
    }
}
