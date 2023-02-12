using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace LootBoxSimulator.Controllers
{
    public class ItemController : Controller
    {
        [SerializeField] private GameObject droppedItemPrefab;
        [SerializeField] private List<ItemCreator> itemList = new List<ItemCreator>();
        private float totalPercentage;
        private bool isInitialized = false;
        
        public GameObject InitializeItemPrefab(Vector2 _spawnPosition)
        {
            ItemCreator _droppedItem = DropItem();

            if (_droppedItem != null)
            {
                GameObject _itemGameObject = Instantiate(droppedItemPrefab, _spawnPosition, Quaternion.identity);
                _itemGameObject.GetComponent<Image>().sprite = _droppedItem.GetItemSprite;
                return _itemGameObject;
            }

            return null;
        }

        public GameObject InitializeItemPrefabWithParent(Vector2 _spawnPosition, Transform _parentTransform)
        {
            GameObject _itemPrefab = InitializeItemPrefab(_spawnPosition);
            if (_itemPrefab != null)
            {
                _itemPrefab.transform.SetParent(_parentTransform);
                _itemPrefab.transform.localScale = new Vector2(1,1);
            
                return _itemPrefab;
            }
            
            Debug.Log("Nothing to instantiate"); 
            return null;

        }

        
        private void Initialize()
        {
            if (!isInitialized)
            {
                totalPercentage = itemList.Sum(item => item.GetItemDropChance);
                isInitialized = true;
            }
            
        }

       
        

        private ItemCreator DropItem()
        {
            Initialize();

            float _randomItem = Random.Range(0f, totalPercentage);

            foreach (var _item in itemList)
            {
                if (_item.GetItemDropChance >= _randomItem)
                {
                    return _item;
                }

                _randomItem -= _item.GetItemDropChance;
            }
            
            Debug.Log("No items dropped");
            return null;
        }
    }
}
