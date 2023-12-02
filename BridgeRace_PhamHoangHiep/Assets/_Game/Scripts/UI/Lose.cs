using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace BridgeRace{
public class Lose : UICanvas
{
    public TextMeshProUGUI scoreText;

    public void ReturnButton()
    {
        UIManager.Ins.OpenUI<MainMenu>();
        Close(0);
    }
}

}