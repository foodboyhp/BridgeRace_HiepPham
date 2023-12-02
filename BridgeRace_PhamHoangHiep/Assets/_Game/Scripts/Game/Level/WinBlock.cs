using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BridgeRace{
public class WinBlock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        BaseCharacter character = other.GetComponent<BaseCharacter>();
        if (character != null)
        {
            LevelManager.Ins.OnFinishGame();
            if (other.CompareTag(Constants.TAG_PLAYER))
            {
                UIManager.Ins.OpenUI<Victory>();
            }
            else
            {
                UIManager.Ins.OpenUI<Lose>();
            }

            UIManager.Ins.CloseUI<GamePlay>();

            GameManager.Ins.ChangeState(GameState.Pause);

            character.ChangeAnim(Constants.ANIM_DANCE);

            character.TF.eulerAngles = Vector3.up * 180;
            character.OnInit();
        }
    }
}
}