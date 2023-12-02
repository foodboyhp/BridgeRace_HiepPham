using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BridgeRace{
public class MainMenu : UICanvas
{
    public void PlayButton()
    {
        UIManager.Ins.OpenUI<GamePlay>();
        Close(0);
    }
}
}