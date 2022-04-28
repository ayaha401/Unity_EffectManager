using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effect
{
    public class EffectDataDictionary : MonoBehaviour
    {
        [SerializeField] private EffectListSObj _effectListSObj = null;

        private Dictionary<string, GameObject> _effectDic = null;

        // ディクショナリを作成
        private void MakeDictionary()
        {
            _effectDic = new Dictionary<string, GameObject>();
            foreach (GameObject effectObj in _effectListSObj.effectDatas)
            {
                if (_effectDic.ContainsKey(effectObj.name) == false)
                {
                    _effectDic.Add(effectObj.name, effectObj);
                }
            }
        }

        private void Awake()
        {
            MakeDictionary();
        }

        // ディクショナリを返す
        public Dictionary<string, GameObject> GetEffectDic()
        {
            if(_effectDic == null)
            {
                MakeDictionary();
            }

            return _effectDic;
        }
    }
}

