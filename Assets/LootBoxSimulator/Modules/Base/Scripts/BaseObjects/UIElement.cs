using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LootBoxSimulator
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIElement : BaseElement
    {
        public RectTransform RectTransform => transform as RectTransform;
    }
}
