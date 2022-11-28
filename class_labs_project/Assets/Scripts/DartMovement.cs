using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartMovement : MonoBehaviour
{
    private float speed;
    private GameObject player;
    [SerializeField] AudioSource mAudio;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.05f;
        player = GameObject.FindWithTag("Player");
        if (player.GetComponent<PlayerMovement>().isMovingRight() == false)
        {
            transform.Rotate(0, 180, 0);
            speed = -speed;
        }

        if (mAudio == null)
        {
            mAudio = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        transform.position = new Vector2(x + speed, transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Balloon")
        {
            AudioSource.PlayClipAtPoint(mAudio.clip, transform.position);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
