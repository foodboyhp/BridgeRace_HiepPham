using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BridgeRace{
public class AttackState : IState<Enemy>
{
    public void OnEnter(Enemy e)
    {
        
    }

    public void OnExecute(Enemy e)
    {
        if(e.BrickCount == 0){
            e.ChangeState(new PatrolState());
        }
    }

    public void OnExit(Enemy e)
    {

    }

}
}