using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

public class BossAI : MonoBehaviour
{
    public float gameTimer;
    public int seconds = 0;
    public int nextState;
    public bool switchState = false;
    public StateMachine<BossAI> stateMachine { get; set; }
    public Vector2[] platforms;
    public int platformNum = 5;
    public GameObject enemy;
    public GameObject fire;
    public GameObject erf;

    private bool first = true;

    private void Start()
    {
        gameTimer = Time.time + 5;

        stateMachine = new StateMachine<BossAI>(this);

        platforms = new Vector2[] 
        {
           new Vector2(-15.75415f, -8.94f),
           new Vector2(-15.75415f, -4.14f),
           new Vector2(-15.75415f, 1.15f),
           new Vector2(-15.75415f, 5.9f),
           new Vector2(15.7f, -8.97f),
           new Vector2(15.7f, -4.13f),
           new Vector2(15.7f, 1.13f),
           new Vector2(15.7f, 5.87f),
           new Vector2(0f, -8.9f)
        };
        Debug.Log(platforms);
    }

    private void Update()
    {
        if (first && Time.time > gameTimer)
        {
            stateMachine.ChangeState(StateOne.Instance);
            first = false;
        }


        if(Time.time > gameTimer + 1)
        {
            gameTimer = Time.time;
            seconds++;
            Debug.Log("This state has persisted " + seconds + " seconds.");
        }

        if(seconds == 8)
        {
            seconds = 0;
            nextState = Random.Range(1, 3);
            switchState = true;
            Debug.Log("Next State: " + nextState);
        }

        stateMachine.Update();
    }
}
