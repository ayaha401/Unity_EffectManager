using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MegaFist.Effect
{
    public class MyEffectDestroy : MonoBehaviour
    {
        private ParticleSystem _myParticleSystem;

        void Start()
        {
            _myParticleSystem = GetComponent<ParticleSystem>();
        }

        void Update()
        {
            // エフェクトが終了していたら非アクティブ化
            if (_myParticleSystem.isStopped)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

}
