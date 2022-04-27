using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effect
{
    public class EffectManager : MonoBehaviour
    {
        //[SerializeField] GameObject obj;
        private static GameObject _parentObj = null;
        

        private void Awake()
        {
            _parentObj = this.gameObject;
        }

        void Start()
        {
            
        }

        void Update()
        {
            
        }

        public static void EffectPlay(string effectName, Vector2 pos)
        {
            GameObject effectObj = new GameObject("newObj");
            //Instantiate(effectObj, pos, Quaternion.identity);
            effectObj.transform.parent = _parentObj.transform;
        }
    }
}

