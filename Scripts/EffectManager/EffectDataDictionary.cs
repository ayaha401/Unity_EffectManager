using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effect
{
    public class EffectDataDictionary : MonoBehaviour
    {
        [SerializeField] private EffectListSObj _effectListSObj = null;

        private Dictionary<string, GameObject> _effectDic = null;

        // �f�B�N�V���i�����쐬
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

        // �f�B�N�V���i����Ԃ�
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

