using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip deathSound;
    public float shotVolume;
    public float fireRate;
    public GameObject enemyBulletL;
    public GameObject enemyBulletR;

    private EnemyText enemyText;
    private AudioSource source;
    private Vector2 bulletPosLeft;
    private Vector2 bulletPosRight;
    private float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        enemyText = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<EnemyText>();
        nextFire = 1;
    }

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            bulletPosLeft = transform.position;
            Vector2 velocity = new Vector2(-1.2f, 0.2f);
            bulletPosLeft += new Vector2(-1.2f, 0.8f);
            Instantiate(enemyBulletL, bulletPosLeft, Quaternion.identity);

            bulletPosRight = transform.position;
            velocity = new Vector2(+1.2f, 0.2f);
            bulletPosRight += new Vector2(+1.2f, 0.8f);
            Instantiate(enemyBulletR, bulletPosRight, Quaternion.identity);

            nextFire = Time.time + fireRate;
        }
    }

    //Runs when bullet collides with another object
    void OnCollisionEnter2D(Collision2D other)
    {
        char bulletLetter = other.gameObject.GetComponent<BulletScript>().letter;
        bool dead = enemyText.Hit(bulletLetter);

        if (dead)
        {
            source.PlayOneShot(deathSound, shotVolume);
            Destroy(gameObject, 1.0f);
        }

        Destroy(other.gameObject);
    }
}
