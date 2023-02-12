using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LootBoxSimulator
{
    public abstract class BaseDirector : MonoBehaviour
    {
        protected static BaseDirector instance;
        
        protected virtual void Awake()
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        protected virtual void Start() { }

        protected virtual void OnEnable() { }

        protected virtual void OnDisable() { }

       

        protected virtual void OnApplicationPause(bool _pause)
        {
            
        }

        protected virtual void OnApplicationFocus(bool _focus)
        {
            
        }

        protected virtual void OnApplicationQuit()
        {
            
        }

        
    }
}
