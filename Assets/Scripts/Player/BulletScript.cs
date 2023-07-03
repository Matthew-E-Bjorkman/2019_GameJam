using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float velX;
    public char letter;

    private float velY;
    private Rigidbody2D rb2d;
    private BulletText TextScript;

    // Start is called before the first frame update
    void Start()
    {
        velY = 0;
        rb2d = GetComponent<Rigidbody2D>();

        //TextScript = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<BulletText>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 3f);
    }

    public void SetLetter (char newLetter)
    {
        letter = newLetter;
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<BulletText>().SetLetter(letter);
    }

    //Runs when bullet collides with another object
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bullet") || other.gameObject.CompareTag("enemy_bullet"))
        {
            return;
        }

        Destroy(gameObject);
    }
}
