using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

/*
 *
 *
 * STATE TWO: Attaks half the screen :)
 * 
 * 
 * 
*/
public class StateTwo : State<BossAI>
{
    private static StateTwo _instance;

    private Vector2 spot;
    private Vector2[] hitboxSpots = new Vector2[]
        {
           new Vector2(0.0f, 4.5f),
           new Vector2(0.0f, -4.5f)
        };
    private GameObject fireZone;
    private float counter = 0;

    private StateTwo()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static StateTwo Instance
    {
        get
        {
            if (_instance == null)
            {
                new StateTwo();
            }

            return _instance;
        }
    }

    public override void EnterState(BossAI _owner)
    {
        Debug.Log("Entering State Two");

        spot = hitboxSpots[Random.Range(0, 2)];
        fireZone = GameObject.Instantiate(_owner.fire, spot, Quaternion.identity) as GameObject;

        fireZone.GetComponent<SpriteRenderer>().color = new Color(200f, 20f, 20f, 0f);
        counter = 0;
    }

    public override void ExitState(BossAI _owner)
    {
        Debug.Log("Exiting State Two");

        GameObject.Destroy(fireZone);
    }

    public override void UpdateState(BossAI _owner)
    {
        if (_owner.switchState)
        {
            _owner.switchState = false;

            _owner.stateMachine.ChangeState(StateThree.Instance);
        }

        if (counter == 50)
        {
            fireZone.GetComponent<SpriteRenderer>().color = new Color(200, 20, 20, .25f);
        }

        if (counter == 100)
        {
            fireZone.GetComponent<SpriteRenderer>().color = new Color(200, 20, 20, .5f);
        }

        if (counter == 200)
        {
            fireZone.GetComponent<SpriteRenderer>().color = new Color(200, 20, 20, .75f);
        }

        if (counter == 350)
        {
            fireZone.GetComponent<SpriteRenderer>().color = new Color(200, 20, 20, 1f);
            fireZone.GetComponent<Collider2D>().enabled = true;
        }

        counter++;

    }
}
