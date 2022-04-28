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

        // ParticleSystem��ݒ�
        private static void ParticleSystemSetting(GameObject effectObj)
        {
            if(effectObj.GetComponent<ParticleSystem>() == null) return;

            ParticleSystem.MainModule particleSystem = effectObj.GetComponent<ParticleSystem>().main;
            particleSystem.stopAction = ParticleSystemStopAction.Disable;
        }

        // �f�B�N�V���i������G�t�F�N�g���擾
        private static void GetEffect(EffectDataDictionary dataDic, string effectName, Vector2 pos, GameObject rootObj)
        {
            Dictionary<string, GameObject> effectDic = dataDic.GetEffectDic();
            if (effectDic.ContainsKey(effectName) == false)
            {
                Debug.Log("�Ή�����string : " + effectName + "������܂���");
                return;
            }

            GameObject effectObj = effectDic[effectName];

            ParticleSystemSetting(effectObj);

            effectObj = Instantiate(effectObj, pos, Quaternion.identity);
            effectObj.transform.parent = rootObj.transform;
        }

        // �w����W�ɃG�t�F�N�g�𔭐�
        public static void EffectPlay(EffectDataDictionary dataDic, string effectName, Vector2 pos)
        {
            GetEffect(dataDic, effectName, pos, _parentObj);
        }

        // ���w��I�u�W�F�N�g�̎q�I�u�W�F�N�g�Ƃ��ăG�t�F�N�g�𔭐�
        public static void EffectTrackingPlay(EffectDataDictionary dataDic, string effectName, Vector2 pos, GameObject rootObj)
        {
            GetEffect(dataDic, effectName, pos, rootObj);
        }
    }
}

