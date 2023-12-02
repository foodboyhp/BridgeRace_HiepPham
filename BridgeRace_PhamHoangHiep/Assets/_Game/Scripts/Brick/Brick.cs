using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BridgeRace{
    public class Brick : ColorObject {

        public Stage stage;
        public override void OnInit(){
            ChangeColor((ColorType)Random.Range(0,5));
        }

        public void OnDespawn(){
            stage.RemoveBrick(this);
        }
    }
}