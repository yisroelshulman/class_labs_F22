using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class BirdControl : MonoBehaviour
{

    [SerializeField] Animator animator;

    [SerializeField] float speed;
    private float attackSpeed;
    private float x;
    private float y;
    private const float RIGHTB = 10.2f;
    private const float LEFTB = -10.2f;
    private const float UPPERB = 5.64f;
    private const float LOWERB = -3.55f;
    private const float UNLOAD = -4.32f;
    private bool fall;

    [SerializeField] GameObject player;
    private float distance;
    private const int DISTALLOWED = 5;

    private int level;
    private bool isEasyMode;

    // Start is called before the first frame update
    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        level = SceneManager.GetActiveScene().buildIndex;
        isEasyMode = PersistentData.Instance.GetGameModeEasy();

        speed = 0.1F;
        fall = false;
        attackSpeed = speed/3;

    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;

        if (!isEasyMode && level == 3)
        {
            distance = Vector3.Distance (transform.position, player.transform.position);
            if (distance < DISTALLOWED)
            {
                attack();
            }
        }
    }

    void FixedUpdate()
    {
        if (fall)
        {
            if (y <= UNLOAD)
            {
                Destroy(gameObject);
            }
            transform.position = new Vector2(x, y - speed);
        }
        else
        {
        if (x >= RIGHTB || x <= LEFTB)
            {
                FlipX();
            }
            transform.position = new Vector2(x + speed, y);
        }
    }

    void attack()
    {
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        if (x >= RIGHTB || x <= LEFTB)
        {
            transform.Rotate(0, 180, 0);
        }
        if (playerX > x)
        {
            x = x + attackSpeed;
        }
        if (playerX < x)
        {
            x = x - attackSpeed;
        }
        if (playerY > y)
        {
            y = y + attackSpeed;
        }
        if (playerY < y)
        {
            y = y - attackSpeed;
        }
        transform.position = new Vector2(x, y);
    } 

    void FlipX()
    {
        speed = -speed;
        transform.Rotate(0, 180, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dart")
        {
            speed = 0.05f;
            animator.SetBool("isAlive", false);
            fall = true;
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
