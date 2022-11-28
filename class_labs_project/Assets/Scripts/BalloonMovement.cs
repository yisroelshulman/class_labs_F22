using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{

    [SerializeField] GameObject controller;

    [SerializeField] float speed;
    private float startDelay = 3.0f;
    private float repeatDelay = 1.0f;
    private float growRate = 0.05f;

    private int counter = 0;
    private const int MAXPOINTS = 15;
    private int multiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
        speed = 0.01F;
        InvokeRepeating("grow", startDelay, repeatDelay);
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        transform.position = new Vector2(x + speed, transform.position.y);
    }

    void grow()
    {
        float x = transform.localScale.x + growRate;
        float y = transform.localScale.y + growRate;
        transform.localScale = new Vector2(x, y);
        counter++;
        if (counter == MAXPOINTS)
        {
            Destroy(gameObject);
        }
    }

    // when the balloon collides with the wall it reverses direction
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Boundary")
        {
            speed = -speed;
        }
        if (collision.gameObject.tag == "Dart")
        {
            controller.GetComponent<ScoreRecorder>().AddPoints(multiplier * (MAXPOINTS - counter));
        }
    }
}
