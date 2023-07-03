using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

/*
 *
 *
 * STATE ONE: SUMMONS 2 GENERIC ENEMIES ON THE PLATFORMS
 * 
 * 
 * 
*/
public class StateOne : State<BossAI>
{

    private static StateOne _instance;

    private Vector2 platform1, platform2;
    private int platformNum1, platformNum2;
    private Vector2[] platforms = new Vector2[] 
        {
           new Vector2(-15.75415f, -8.94f),
           new Vector2(-15.75415f, -4.14f),
           new Vector2(-15.75415f, 1.15f),
           new Vector2(-15.75415f, 5.9f),
           new Vector2(15.7f, -8.97f),
           new Vector2(15.7f, -4.13f),
           new Vector2(15.7f, 1.13f),
           new Vector2(15.7f, 5.87f)
        };

private StateOne()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static StateOne Instance
    {
        get
        {
            if(_instance == null)
            {
                new StateOne();
            }

            return _instance;
        }
    }

    public override void EnterState(BossAI _owner)
    {
        Debug.Log("Entering State One");

        platformNum1 = Random.Range(0, 8);
        platformNum2 = Random.Range(0, 8);

        while (platformNum1 == platformNum2 || platformNum1 == _owner.platformNum || platformNum2 == _owner.platformNum)
        {
            platformNum1 = Random.Range(0, 8);
            platformNum2 = Random.Range(0, 8);
        }

        Debug.Log("Enemy 1 platform: " + platformNum1);
        Debug.Log("Enemy 2 platform: " + platformNum2);

        platform1 = platforms[platformNum1];
        platform2 = platforms[platformNum2];

        GameObject.Instantiate(_owner.enemy, platform1, Quaternion.identity);
        GameObject.Instantiate(_owner.enemy, platform2, Quaternion.identity);
    }

    public override void ExitState(BossAI _owner)
    {
        Debug.Log("Exiting State One");
    }

    public override void UpdateState(BossAI _owner)
    {
        if (_owner.switchState)
        {
            _owner.switchState = false;

            _owner.stateMachine.ChangeState(StateThree.Instance);
        }
    }
}
