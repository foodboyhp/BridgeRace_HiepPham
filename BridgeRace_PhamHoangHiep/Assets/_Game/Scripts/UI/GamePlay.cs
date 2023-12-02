using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BridgeRace{
public class GamePlay : UICanvas
{
    

    public void SettingButton()
    {
        UIManager.Ins.OpenUI<Setting>();
    }
}
}