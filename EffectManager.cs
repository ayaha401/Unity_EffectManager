using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField, Tooltip("Effect")]
    List<GameObject> _effectList = new List<GameObject>();

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
            for (int i = 0; i < _parentObj.transform.childCount; i++)
            {
                if (_parentObj.transform.GetChild(i).gameObject.activeSelf == false && _parentObj.transform.GetChild(i).gameObject.name == effectName)
                {
                    nonActiveEffectObj = _parentObj.transform.GetChild(i).gameObject;
                    break;
                }
            }

            if (nonActiveEffectObj == null)
            {
                // 足りないのでInstantiate
                getEffectObj = Instantiate(getEffectObj, pos, Quaternion.identity);
                getEffectObj.name = effectName;
                getEffectObj.transform.parent = _parentObj.transform;
            }
            else
            {
                // SetActive trueにする
                nonActiveEffectObj.transform.position = pos;
                nonActiveEffectObj.SetActive(true);
            }
        }
    }

    // オブジェクトにくっつくようにエフェクトを出す
    public static void EffectTrackingPlay(string effectName, Vector2 pos, GameObject rootObj)
    {
        GameObject getEffectObj;
        getEffectObj = GetEffect(effectName);
        if (getEffectObj != null)
        {
            GameObject nonActiveEffectObj = null;
            for (int i = 0; i < rootObj.transform.childCount; i++)
            {
                if (rootObj.transform.GetChild(i).gameObject.activeSelf == false && rootObj.transform.GetChild(i).gameObject.name == effectName)
                {
                    nonActiveEffectObj = rootObj.transform.GetChild(i).gameObject;
                    break;
                }
            }

            if (nonActiveEffectObj == null)
            {
                // 足りないのでInstantiate
                getEffectObj = Instantiate(getEffectObj, pos, Quaternion.identity);
                getEffectObj.name = effectName;
                getEffectObj.transform.parent = rootObj.transform;
            }
            else
            {
                // SetActive trueにする
                nonActiveEffectObj.transform.position = pos;
                nonActiveEffectObj.transform.parent = rootObj.transform;
                nonActiveEffectObj.SetActive(true);
            }
        }
    }
}
