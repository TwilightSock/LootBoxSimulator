using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LootBoxSimulator.Screens.Menu
{
    public class MenuScreen : BaseTemplateScreen
    {
        public const string Exit_Play = "Exit_Play";

        public void OnExitPressed()
        {
            Exit(Exit_Play);
        }
        
    }
}
