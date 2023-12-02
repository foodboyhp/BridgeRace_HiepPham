using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BridgeRace{
    public class GameUnit : MonoBehaviour
    {
        private Transform tf;
        public Transform TF
        {
            get
            {
                tf = tf ?? gameObject.transform;
                return tf;
            }
        }

        public PoolType poolType;

        public void OnDespawn()
        {
        }
    }

}