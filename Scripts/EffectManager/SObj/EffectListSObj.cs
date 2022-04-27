using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Effect
{
    [CreateAssetMenu(menuName = "EffectManager/EffectListData")]
    public class EffectListSObj : ScriptableObject
    {
        [SerializeField] public List<GameObject> effectDatas = new List<GameObject>();
    }
}

