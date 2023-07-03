using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private BossText bossText;

    void Start()
    {
        bossText = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<BossText>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        char bulletLetter = other.gameObject.GetComponent<BulletScript>().letter;
        bool dead = bossText.Hit(bulletLetter);

        if (dead)
        {
            bossText.nextLine(gameObject);
            gameObject.transform.position = new Vector2(0f, -8.9f);
        }

        Destroy(other.gameObject);
    }
}
