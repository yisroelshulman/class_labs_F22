using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
	private float hMovement;
    private float vMovement;
	public int hSpeed = 3;
    public int vSpeed = 6;
	[SerializeField] bool isFacingRight = true;
    [SerializeField] GameObject Dart;
    [SerializeField] AudioSource mAudio;
    
    private const float XOFFSETR = 0.5f;
    private const float XOFFSETL = -0.5f;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
		if (rigid == null)
			rigid = GetComponent<Rigidbody2D>();
        if (mAudio == null)
        {
            mAudio = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    //good for user input
    void Update()
    {
		hMovement = Input.GetAxis("Horizontal");
        vMovement = Input.GetAxis("Vertical");
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            spawnDart();
        }
    }

    //called potentially multiple times per frame
    //use for physics/movement
    void FixedUpdate()
	{
		rigid.velocity = new Vector2(hMovement * hSpeed, vMovement * vSpeed);
		if ((hMovement < 0 && isFacingRight) || (hMovement > 0 && !isFacingRight))
			Flip();
	}

    void spawnDart()
    {
        AudioSource.PlayClipAtPoint(mAudio.clip, transform.position);
        float x = transform.position.x + XOFFSETL;
        if (isFacingRight)
        {
            x = transform.position.x + XOFFSETR;
        }
        float y = transform.position.y;
        Vector2 position = new Vector2(x, y);
        Instantiate(Dart, position, Quaternion.identity);
    }

    // flips the sprite horizontally to change directions
    void Flip()
	{
		transform.Rotate(0, 180, 0);
		isFacingRight = !isFacingRight; 
	}

    public bool isMovingRight()
    {
        return isFacingRight;
    }
}
