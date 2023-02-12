using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

namespace LootBoxSimulator.Screens.Menu
{
    public class MenuScreen : BaseTemplateScreen
    {
        public const string Exit_Play = "Exit_Play";

        [SerializeField] private GameObject openCasePanel;
        

        public void OnOpenCratePressed()
        {
            openCasePanel.SetActive(true);
        }
        
        public void OnTryAgainPressed()
        {
            SceneManager.LoadScene("Menu");
        }

        public void OnExitPressed()
        {
            Exit(Exit_Play);
        }
        
    }
}
