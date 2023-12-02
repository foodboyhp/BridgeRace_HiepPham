using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BridgeRace 
{
    public enum ColorType { Black, Red, Blue, Green, Yellow, Orange, Brown, Violet }
    [CreateAssetMenu(menuName = "ColorData")]
    public class ColorData : ScriptableObject
    {
        //theo tha material theo dung thu tu ColorType
        [SerializeField] Material[] materials;

        //lay material theo mau tuong ung
        public Material GetMat(ColorType colorType)
        {
            return materials[(int)colorType];
        }
    }
}
