using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BridgeRace{
    public class ColorObject : GameUnit {
        //keo tha color data vao
        [SerializeField] ColorData colorData;
        //keo mesh renderer vao
        [SerializeField] Renderer meshRenderer;
        public ColorType color;

        private void Awake(){
            OnInit();
        }
        public virtual void OnInit(){}

        //thay doi mau object
        public void ChangeColor(ColorType colorType)
        {
            color = colorType;
            meshRenderer.material = colorData.GetMat(colorType);
        }
    }
}
