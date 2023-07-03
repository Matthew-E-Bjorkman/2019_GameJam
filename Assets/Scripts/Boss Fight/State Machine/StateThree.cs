using UnityEngine;
using States;

public class StateThree : State<BossAI>
{
    private static StateThree _instance;
    private BossFight bossFight;

    public int timer;

    public bool finished;
    

    private StateThree()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;

        bossFight = new BossFight(this);
    }

    public static StateThree Instance
    {
        get
        {
            if (_instance == null)
            {
                new StateThree();
            }

            return _instance;
        }
    }

    public override void EnterState(BossAI _owner)
    {
        Debug.Log("Entering State Three");

        timer = 0;

        _owner.erf.transform.position = _owner.platforms[Random.Range(0, 8)];
    }

    public override void ExitState(BossAI _owner)
    {
        Debug.Log("Exiting State Three");

        _owner.erf.transform.position = _owner.platforms[8];
    }

    public override void UpdateState(BossAI _owner)
    {
        if (finished || timer == 1000)
        {
            _owner.switchState = false;
            switch (Random.Range(0,2))
            {
                case 0:
                    _owner.stateMachine.ChangeState(StateOne.Instance);
                    break;
                case 1:
                    _owner.stateMachine.ChangeState(StateTwo.Instance);
                    break;
                default:
                    break;
            }
        }

        timer++;
    }
}
