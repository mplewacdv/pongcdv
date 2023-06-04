using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speed = 9f;
    public Vector3 vel;
    public bool isPlaying;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        ResetBall();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && isPlaying == false)
        {
            ResetAndSendBallInRandomDirection();
        }

        if (rb2D.velocity.magnitude < speed * .5f)
        {
            ResetBall();
        }
    }

    private void ResetBall()
    {
        rb2D.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        isPlaying = false;
    }

    private void ResetAndSendBallInRandomDirection()
    {
        ResetBall();
        rb2D.velocity = GenerateRandomVelocity(true) * speed;
        vel = rb2D.velocity;
        isPlaying = true;
    }

    private Vector3 GenerateRandomVelocity(bool shouldReturnNormalized)
    {
        Vector3 velocity = new Vector3();
        bool shouldGoRight = Random.Range(1, 100) > 50;
        velocity.x = shouldGoRight ? Random.Range(.8f, .3f) : Random.Range(-.8f, -.3f);
        velocity.y = shouldGoRight ? Random.Range(.8f, .3f) : Random.Range(-.8f, -.3f);

        if (shouldReturnNormalized)
        {
            return velocity.normalized;
        }
        return velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2D.velocity = Vector3.Reflect(vel, collision.contacts[0].normal);
        Vector3 newVelocityWithOffset = rb2D.velocity;
        newVelocityWithOffset += new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f));
        rb2D.velocity = newVelocityWithOffset.normalized * speed;
        vel = rb2D.velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0)
        {
            print("Left Player scores");
        }
        
        if (transform.position.x < 0)
        {
            print("Right Player scores");
        }

        ResetBall();
    }
}
