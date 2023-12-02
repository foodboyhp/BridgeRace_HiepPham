using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BridgeRace{
public class Victory : UICanvas
{
    //public TextMeshProUGUI scoreText;

    public void MainMenuButton()
    {
        UIManager.Ins.OpenUI<MainMenu>();
        Close(0);
    }
    public void NextLevelButton(){

    }
}
}