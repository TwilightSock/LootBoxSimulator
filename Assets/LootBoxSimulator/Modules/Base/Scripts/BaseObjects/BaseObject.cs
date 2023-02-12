using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LootBoxSimulator
{
    public abstract class BaseObject : MonoBehaviour
    {

        protected virtual void OnEnable()
        {
            
        }

        protected virtual void OnDisable()
        {
            
        }

        public virtual void SetActive(bool _isActive)
        {
            Debug.Log($"{name}, Set active: " + _isActive);
            gameObject.SetActive(_isActive);
        }

        public void DestroyObj()
        {
            Destroy(gameObject);
        }

        public void DestroyObj(float _delay)
        {
            Destroy(gameObject,_delay);
        }

        public bool IsObjectActive => gameObject.activeSelf;
    }
}
