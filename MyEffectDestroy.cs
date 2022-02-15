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
            // �G�t�F�N�g���I�����Ă������A�N�e�B�u��
            if (_myParticleSystem.isStopped)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

}
