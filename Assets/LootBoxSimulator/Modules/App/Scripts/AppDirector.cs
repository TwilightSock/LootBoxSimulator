using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LootBoxSimulator.App
{
    public class AppDirector : BaseDirector
    {
        protected override void Start()
        {
            base.Start();

            SceneManager.LoadScene(SceneIds.Menu);
        }
    }
}
