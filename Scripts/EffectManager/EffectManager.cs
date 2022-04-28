using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effect
{
    public class EffectManager : MonoBehaviour
    {
        private static GameObject _parentObj = null;
        
        private void Awake()
        {
            _parentObj = this.gameObject;
        }

        void Start()
        {
            
        }

        // ParticleSystemを設定
        private static void ParticleSystemSetting(GameObject effectObj)
        {
            if(effectObj.GetComponent<ParticleSystem>() == null) return;

            ParticleSystem.MainModule particleSystem = effectObj.GetComponent<ParticleSystem>().main;
            particleSystem.stopAction = ParticleSystemStopAction.Disable;
        }

        // ディクショナリからエフェクトを取得
        private static void GetEffect(EffectDataDictionary dataDic, string effectName, Vector2 pos, GameObject rootObj)
        {
            Dictionary<string, GameObject> effectDic = dataDic.GetEffectDic();
            if (effectDic.ContainsKey(effectName) == false)
            {
                Debug.Log("対応するstring : " + effectName + "がありません");
                return;
            }

            GameObject effectObj = effectDic[effectName];

            ParticleSystemSetting(effectObj);

            effectObj = Instantiate(effectObj, pos, Quaternion.identity);
            effectObj.transform.parent = rootObj.transform;
        }

        // 指定座標にエフェクトを発生
        public static void EffectPlay(EffectDataDictionary dataDic, string effectName, Vector2 pos)
        {
            GetEffect(dataDic, effectName, pos, _parentObj);
        }

        // し指定オブジェクトの子オブジェクトとしてエフェクトを発生
        public static void EffectTrackingPlay(EffectDataDictionary dataDic, string effectName, Vector2 pos, GameObject rootObj)
        {
            GetEffect(dataDic, effectName, pos, rootObj);
        }
    }
}

