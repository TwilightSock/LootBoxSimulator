using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public void OnExitPressed()
        {
            Exit(Exit_Play);
        }
        
    }
}
