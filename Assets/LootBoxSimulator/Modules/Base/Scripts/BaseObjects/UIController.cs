using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LootBoxSimulator
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIController : BaseController
    {
        public Canvas FindCanvas()
        {
            return transform.GetComponentInParent<Canvas>();
        }
        
        public RectTransform RectTransform => transform as RectTransform;
    }
}
