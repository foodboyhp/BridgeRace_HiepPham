using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BridgeRace{
public class PatrolState : IState<Enemy>
{
    int targetBrick;
    public void OnEnter(Enemy e)
    {
        e.ChangeAnim(Constants.ANIM_RUN);
        targetBrick = Random.Range(2,7);
        SeekTarget(e);
    }

    public void OnExecute(Enemy e)
    {
        if (e.IsDestination)
        {
            if (e.BrickCount >= targetBrick)
            {
                e.ChangeState(new AttackState());
            }
            else
            {
                SeekTarget(e);
            }
        }
    }

    public void OnExit(Enemy e)
    {

    }
    private void SeekTarget(Enemy e)
    {
        if (e.stage != null)
        {
            Brick brick = e.stage.SeekBrickPoint(e.color);

            if (brick == null)
            {
                e.ChangeState(new AttackState());
            }
            else
            {
                e.SetDestination(brick.TF.position);
            }
        }
        else
        {
            e.SetDestination(e.TF.position);
        }
    }
}
}