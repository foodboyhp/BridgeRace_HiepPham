using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BridgeRace{
public class StartStageBox : MonoBehaviour
{
    public Stage stage;
    private List<ColorType> colorTypes = new List<ColorType>();

    private void OnTriggerEnter(Collider other)
    {
        //Character character = Cache.GetCharacter(other);
        BaseCharacter character = other.GetComponent<BaseCharacter>();
        if ( character != null && !colorTypes.Contains(character.color))
        {
            colorTypes.Add(character.color);    
            character.stage = stage;
            stage.InitColor(character.color);
        }
    }
}
}