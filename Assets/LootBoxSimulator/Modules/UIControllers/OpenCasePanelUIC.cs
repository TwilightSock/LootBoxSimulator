using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootBoxSimulator;
using LootBoxSimulator.Controllers;

namespace LootBoxSimulator.UIControllers
{
    public class OpenCasePanelUIC : UIController
    {
        [SerializeField] private int amountOfItems;
        [SerializeField] private GameObject scrollPanel;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            
            SimulateCase();
        }
        

        private void SimulateCase()
        {
            for (int a = 0; a < amountOfItems; a++)
            {
               GetComponent<ItemController>().InitializeItemPrefabWithParent(new Vector3(0,0,1), scrollPanel.transform);

            }
            
        }
    }
}
