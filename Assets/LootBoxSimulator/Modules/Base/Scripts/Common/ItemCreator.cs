using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LootBoxSimulator
{
    [CreateAssetMenu]
    public class ItemCreator : ScriptableObject
    {
        [SerializeField] private Sprite itemSprite;
        [SerializeField] private string itemName;
        [SerializeField] private float dropChance;

        public ItemCreator(string _lootName, Sprite _itemSprite ,int _dropChance)
        {
            this.itemSprite = _itemSprite;
            this.itemName = _lootName;
            this.dropChance = _dropChance;
        }


        public Sprite GetItemSprite => itemSprite;
        public string GetItemName => itemName;
        public float GetItemDropChance => dropChance;

    }
}
