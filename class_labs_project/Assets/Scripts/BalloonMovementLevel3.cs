using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonMovementLevel3 : MonoBehaviour
{

    [SerializeField] GameObject controller;
    [SerializeField] Animator animator;


    [SerializeField] AudioSource mAudio;
    private Vector2 soundPos = new Vector2(0.0f, 0.0f);



    [SerializeField] float speed;
    [SerializeField] float yspeed;
    private float startDelay = 3.0f;
    private float repeatDelay = 1.0f;
    private float growRate = 0.05f;
    public int counter = 0;
    private const int MAXPOINTS = 15;
    private int multiplier = 1;
    private float x;
    private const int MINPOINTS = 1;
    private const float RIGHTB = 10.2f;
    private const float LEFTB = -10.2f;

    private const int IDLE = 0;
    private const int POP = 1;

    [SerializeField] GameObject player;
    private float distance;
    private const int DISTALLOWED = 4;
    private const float TOPB = 5.4f;
    private const float BOTTOMB = -3.1f;

    private bool gameModeEasy;

    

    // Start is called before the first frame update
    void Start()
    {
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
        if (mAudio == null)
        {
            mAudio = GetComponent<AudioSource>();
        }
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        animator.SetInteger("pop", IDLE);
        speed = 0.05F;
        yspeed = speed / 2;
        InvokeRepeating("Grow", startDelay, repeatDelay);

        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        gameModeEasy = PersistentData.Instance.GetGameModeEasy();
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        distance = Vector3.Distance (transform.position, player.transform.position);
        if (distance < DISTALLOWED)
        {
            Flee();
        }
    }

    void FixedUpdate()
    {
        if (x >= RIGHTB - (counter*growRate / 2) || x <= LEFTB + (counter * growRate / 2))
        {
            FlipX();
        }
        transform.position = new Vector2(x + speed, transform.position.y);
    }

    void Flee()
    {
        float y = transform.position.y;
        if (x >= RIGHTB - (counter*growRate / 2) || x <= LEFTB + (counter * growRate / 2))
        {
            FlipX();
        }
        if (y >= TOPB - (counter*growRate/2) || y <= BOTTOMB * growRate / 2)
        {
            FlipY();
        }
        transform.position = new Vector2(x + speed, y + yspeed);
    } 

    void Grow()
    {
        counter++;
        float x = transform.localScale.x + growRate;
        float y = transform.localScale.y + growRate;
        transform.localScale = new Vector2(x, y);
        if (counter >= MAXPOINTS)
        {
            PersistentData.Instance.SetHasLevelReset(true);
            PersistentData.Instance.SetBirdCount(0);
            Destroy(gameObject);            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void FlipX()
    {
        speed = -speed;
    }

    void FlipY()
    {
        yspeed = -yspeed;
    }

    //when the balloon collides with the wall it reverses direction
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dart")
        {
            speed = 0;
            AudioSource.PlayClipAtPoint(mAudio.clip, soundPos);
            animator.SetInteger("pop", POP);
            int points = multiplier * (MAXPOINTS - counter);
            if (PersistentData.Instance.GetHasLevelReset())
            {
                points = MINPOINTS;
            }
            controller.GetComponent<ScoreRecorder>().AddPoints(points);
            PersistentData.Instance.SetBirdCount(0);
            StartCoroutine(BalloonPop(mAudio.clip.length));
        }
    }

    IEnumerator BalloonPop(float waitTime)
    {
        yield return new WaitForSecondsRealtime(waitTime);
        Destroy(gameObject);
        SceneManager.LoadScene("HighScores");
    }
}
