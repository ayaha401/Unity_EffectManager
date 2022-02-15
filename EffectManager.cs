using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MegaFist.Effect
{
    public class EffectManager : MonoBehaviour
    {
        [SerializeField, Tooltip("Effect")]
        List<GameObject> _effectList = new List<GameObject>();

        private static List<GameObject> _effectObjs = new List<GameObject>();

        private static Dictionary<string, GameObject> _effectDictionary = new Dictionary<string, GameObject>();

        public static bool effectManagerMaked = false;
        private static GameObject _parentObj = null;

        void Awake()
        {
            if (effectManagerMaked == false)
            {
                DontDestroyOnLoad(this);
                _parentObj = this.gameObject;
                effectManagerMaked = true;
            }
            else
            {
                Destroy(this);
            }

            foreach (GameObject item in _effectList)
            {
                if (_effectDictionary.ContainsKey(item.name) == true)
                {
                    return;
                }
                _effectDictionary.Add(item.name, item);
            }
        }

        void Start()
        {

        }

        // ディクショナリから指定されたエフェクトオブジェクトを返す
        private static GameObject GetEffect(string effectName)
        {
            if (_effectDictionary.ContainsKey(effectName) == true)
            {
                return _effectDictionary[effectName];
            }
            else
            {
                return null;
            }
        }

        // オブジェクトプールを使用してエフェクトを出す
        public static void EffectPlay(string effectName, Vector2 pos)
        {
            GameObject getEffectObj;
            getEffectObj = GetEffect(effectName);
            if (getEffectObj != null)
            {
                GameObject nonActiveEffectObj = null; 
                for(int i=0;i<_effectObjs.Count;i++)
                {
                    if(_effectObjs[i].activeSelf == false)
                    {
                        nonActiveEffectObj = _effectObjs[i];
                        break;
                    }
                }

                if(nonActiveEffectObj == null)
                {
                    // 足りないのでInstantiate
                    getEffectObj = Instantiate(getEffectObj, pos, Quaternion.identity);
                    getEffectObj.transform.parent = _parentObj.transform;
                    _effectObjs.Add(getEffectObj);
                }
                else
                {
                    // SetActive trueにする
                    ParticleSystem getEffectParticleSystem = getEffectObj.GetComponent<ParticleSystem>();
                    ParticleSystem nonActiveEffectObjParticleSystem = nonActiveEffectObj.GetComponent<ParticleSystem>();
                    nonActiveEffectObjParticleSystem = getEffectParticleSystem;
                    nonActiveEffectObj.SetActive(true);
                }
            }
        }
    }
}

