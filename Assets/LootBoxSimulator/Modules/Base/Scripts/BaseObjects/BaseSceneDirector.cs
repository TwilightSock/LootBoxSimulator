using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LootBoxSimulator
{
    public abstract class BaseSceneDirector : MonoBehaviour, IScreenListener
    {
         /// <summary>
        /// All screens must be disabled on start
        /// </summary>
        Dictionary<Type, BaseScreen> screensDict;
        Dictionary<Type, Action<string>> exitActions;
        Stack<BaseScreen> screensStack;

        protected virtual void Start()
        {
            Debug.Log($"{name} Start");

            var _screensCount = transform.childCount;

            screensDict = new Dictionary<Type, BaseScreen>(_screensCount);
            exitActions = new Dictionary<Type, Action<string>>(_screensCount);
            screensStack = new Stack<BaseScreen>(_screensCount);

            for (int i = 0; i < _screensCount; i++)
            {
                var _screen = transform.GetChild(i).GetComponent<BaseScreen>();
                if (_screen)
                {
                    screensDict.Add(_screen.GetType(), _screen);
                    _screen.Init(this);
                }
            }
        }

        protected void AddExitAction<T>(Action<string> _exitAction) where T : BaseScreen
        {
            Type _type = typeof(T);
            
            exitActions.Add(_type, _exitAction);
        }

        protected T SetCurrentScreen<T>() where T : BaseScreen
        {

            BaseScreen _nextScreen = screensDict[typeof(T)];

            if (BackScreen == _nextScreen)
                screensStack.Pop();
            else
                screensStack.Push(CurrentScreen);

            SwitchToScreen(_nextScreen);

            return CurrentScreen as T;
        }

        protected void ToScreen<T>() where T : BaseScreen
        {

            SetCurrentScreen<T>().Show();
        }

        protected void ToBackScreen()
        {
            var _nextScreen = screensStack.Pop();

            SwitchToScreen(_nextScreen);

            CurrentScreen.Show();
        }

        protected void ClearBackScreens()
        {

            screensStack.Clear();
        }

        protected void LoadScene(string _sceneName, LoadSceneMode _mode = LoadSceneMode.Single)
        {
            Debug.Log($"LoadScene: '{_sceneName}'");

            CurrentScreen?.Hide();
            SceneManager.LoadScene(_sceneName, _mode);
        }
        

        protected virtual void HandleScreenExit(BaseScreen _screen, string _exitCode)
        {
            exitActions[_screen.GetType()].Invoke(_exitCode);
        }

        void SwitchToScreen(BaseScreen _toScreen)
        {

            if (CurrentScreen)
            {
                CurrentScreen.Hide();
            }
            
            CurrentScreen = _toScreen;
            
        }

        void IScreenListener.OnScreenExit(BaseScreen _screen, string _exitCode)
        {
            HandleScreenExit(_screen, _exitCode);
        }

        protected BaseScreen CurrentScreen { get; private set; }
        protected BaseScreen BackScreen => screensStack.Count > 0 ? screensStack.Peek() : null;
        
    }
}
