using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float velX;
    public AudioClip hurtSound;
    public float hurtVolume;
    //public GameObject sfxPlayer;

    private float velY;
    private Rigidbody2D rb2d;
    private AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        velY = 0;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 5f);
    }

    //Runs when bullet collides with another object
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            //Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), GetComponent<Collider>(), true);
            return;
        }

        if (other.gameObject.CompareTag("character"))
        {
            source.PlayOneShot(hurtSound, hurtVolume);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("wall") || other.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
            return;
        }

        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, 3.0f);
    }
}
