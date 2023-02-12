using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LootBoxSimulator
{
    public abstract class BaseScreen : BaseObject
    {
        private IScreenListener listener;

        protected virtual void Update()
        {
            
        }

        public virtual void Init(IScreenListener _listener)
        {
            listener = _listener;
        }

        public virtual void Show()
        {
            SetActive(true);
        }

        public virtual void Hide()
        {
            SetActive(false);
        }

        protected virtual void Exit(string _exitCode)
        {
            listener.OnScreenExit(this,_exitCode);
        }

        public bool IsShow => gameObject.activeSelf;
    }

    public interface IScreenListener
    {
        void OnScreenExit(BaseScreen _screen, string _exitCode);
    }
}
