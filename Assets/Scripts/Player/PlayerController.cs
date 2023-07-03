using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;                //Floating point variable to store the player's movement speed.
    public float maxSpeed;
    public Animation idle;
    public Animation moving;
    public int grounded;
    public float jumpHeight;
    //public GameObject ABullet, BBullet, CBullet, DBullet, EBullet, FBullet, GBullet, HBullet, IBullet, JBullet, KBullet, LBullet, MBullet, NBullet, OBullet, PBullet, QBullet, RBullet, SBullet, TBullet, UBullet, VBullet, WBullet, XBullet, YBullet, ZBullet;
    //public GameObject ABulletL, BBulletL, CBulletL, DBulletL, EBulletL, FBulletL, GBulletL, HBulletL, IBulletL, JBulletL, KBulletL, LBulletL, MBulletL, NBulletL, OBulletL, PBulletL, QBulletL, RBulletL, SBulletL, TBulletL, UBulletL, VBulletL, WBulletL, XBulletL, YBulletL, ZBulletL;
    public GameObject BulletLeft;
    public GameObject BulletRight;
    public float fireRate;
    public AudioClip shootSound;
    public float shotVolume;
    public AudioClip stepSound;
    public float stepVolume;
    public float stepRate;
    public AudioClip jumpSound;
    public float jumpVolume;
    public AudioClip landSound;
    public float landVolume;



    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 bulletPos;
    private float nextFire;
    private bool facingRight;
    private AudioSource source;
    private float nextStep;
    private bool jumpPressed;

    //Runs on game startup
    void Start()
    {
        //Creates a reference to the character's physics properties
        rb2d = GetComponent<Rigidbody2D>();
        grounded = 0;
        nextFire = 1;
        nextStep = 0;
        facingRight = true;

        Application.targetFrameRate = 60;
    }

    //Runs when the animation is in an "awake" state
    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
    }



    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("ground"))
        {
            updateJump(1);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            updateJump(1);
        }
    }



    //FixedUpdate is called at a fixed interval and is independent of frame rate.
    void FixedUpdate()
    {
        //Quits on ESC press
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }

        //Reads input direction
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Matches sprite direction to input direction
        if (moveHorizontal > 0.0f) //Moving right
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            facingRight = true;
        }
        else if (moveHorizontal < 0.0f) //Moving left
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            facingRight = false;
        }

        //Jump functionality
        if (jumpPressed && grounded == 1)
        {
            rb2d.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            grounded = 0;
            source.PlayOneShot(jumpSound, jumpVolume);
        }



        //Animation Swap Conditional
        bool moving = (moveHorizontal != 0.0f);
        animator.SetBool("playerMoving", moving);

        if (Time.time > nextStep && rb2d.velocity.x != 0.0f && grounded == 1)
        {
            source.PlayOneShot(stepSound, stepVolume);
            nextStep = Time.time + stepRate;
        }
        
        //Formatting input into output type
        Vector2 movement = new Vector2(moveHorizontal, 0.0f);

        //Applies directional input to character, weighted by speed value in editor
        rb2d.AddForce(movement * speed);

        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
        
    }

    void Update()
    {
        //Reads true only during the first frame the button is pressed. Prevents user from holding down 'jump' and repeatedly jumping
        jumpPressed = Input.GetButton("Jump");


        if (Time.time > nextFire)
        {
            if (Input.GetKeyDown("a")) { Fire('a'); }
            if (Input.GetKeyDown("b")) { Fire('b'); }
            if (Input.GetKeyDown("c")) { Fire('c'); }
            if (Input.GetKeyDown("d")) { Fire('d'); }
            if (Input.GetKeyDown("e")) { Fire('e'); }
            if (Input.GetKeyDown("f")) { Fire('f'); }
            if (Input.GetKeyDown("g")) { Fire('g'); }
            if (Input.GetKeyDown("h")) { Fire('h'); }
            if (Input.GetKeyDown("i")) { Fire('i'); }
            if (Input.GetKeyDown("j")) { Fire('j'); }
            if (Input.GetKeyDown("k")) { Fire('k'); }
            if (Input.GetKeyDown("l")) { Fire('l'); }
            if (Input.GetKeyDown("m")) { Fire('m'); }
            if (Input.GetKeyDown("n")) { Fire('n'); }
            if (Input.GetKeyDown("o")) { Fire('o'); }
            if (Input.GetKeyDown("p")) { Fire('p'); }
            if (Input.GetKeyDown("q")) { Fire('q'); }
            if (Input.GetKeyDown("r")) { Fire('r'); }
            if (Input.GetKeyDown("s")) { Fire('s'); }
            if (Input.GetKeyDown("t")) { Fire('t'); }
            if (Input.GetKeyDown("u")) { Fire('u'); }
            if (Input.GetKeyDown("v")) { Fire('v'); }
            if (Input.GetKeyDown("w")) { Fire('w'); }
            if (Input.GetKeyDown("x")) { Fire('x'); }
            if (Input.GetKeyDown("y")) { Fire('y'); }
            if (Input.GetKeyDown("z")) { Fire('z'); }
        }
    }


        public void updateJump (int ground)
    {
        if(ground == 1)
        {
            source.PlayOneShot(landSound, landVolume);
        }
        grounded = ground;
    }

    void Fire(char letter)
    {
        GameObject bullet;

        nextFire = Time.time + fireRate;
        bulletPos = transform.position;
        if (facingRight)
        {
            Vector2 velocity = new Vector2(+1.2f, 0.2f);

            bulletPos += new Vector2(+1.2f, 0.6f);
            bullet = Instantiate(BulletRight, bulletPos, Quaternion.identity) as GameObject;
        }
        else
        {
            Vector2 velocity = new Vector2(-1.2f, 0.6f);

            bulletPos += new Vector2(-1.2f, 0.6f);
            bullet = Instantiate(BulletLeft, bulletPos, Quaternion.identity) as GameObject;
        }

        bullet.GetComponent<BulletScript>().SetLetter(letter);

        source.PlayOneShot(shootSound, shotVolume);
    }
}