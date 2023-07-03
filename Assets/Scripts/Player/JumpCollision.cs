using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollision : MonoBehaviour
{
    private int grounded;
    private GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            parent.GetComponent<PlayerController>().updateJump(0);
        }
        //Tells the game the character is grounded when they make contact with an object holding the "ground" tag
        if (other.gameObject.CompareTag("ground"))
        {
            parent.GetComponent<PlayerController>().updateJump(1);
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("ground"))
        {
            parent.GetComponent<PlayerController>().updateJump(1);
        }
    }
}