using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartMovement : MonoBehaviour
{
    private float speed;
    private GameObject player;
    private float x;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
        player = GameObject.FindWithTag("Player");
        if (player.GetComponent<PlayerMovement>().isMovingRight() == false)
        {
            transform.Rotate(0, 180, 0);
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(x + speed, transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Bird")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Balloon")
        {
            Debug.Log(this.gameObject.tag);
            Destroy(gameObject);
        }
    }
}
