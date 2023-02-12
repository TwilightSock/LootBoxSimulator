using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootBoxSimulator.Controllers;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace LootBoxSimulator.UIControllers
{
    public class ScrollPanelUIC : UIController
    {
        [SerializeField] private GameObject rewardPanel;
        [SerializeField] private GameObject centerLine;
        [SerializeField] private float scrollSpeed = -20;
        [SerializeField] private float velocity = 2f;
        
        protected override void Update()
        {
            base.Update();
            
            scrollSpeed = Mathf.MoveTowards(scrollSpeed, 0, velocity * Time.deltaTime);
            gameObject.transform.Translate(new Vector2(scrollSpeed,0)*Time.deltaTime);
            RaycastHit2D _hit = Physics2D.Raycast(Vector2.down, Vector2.up);
            if (scrollSpeed == 0 && _hit.collider is not null)
            {
                rewardPanel.transform.Find("RewardItem").gameObject.GetComponent<UnityEngine.UI.Image>().sprite =
                        _hit.collider.gameObject.GetComponent<Image>().sprite;
                rewardPanel.SetActive(true);
            }
            else if (scrollSpeed == 0 && _hit.collider is null)
            {
                scrollSpeed = Mathf.MoveTowards(scrollSpeed, -5f, velocity * Time.deltaTime);
            }


        }

        protected override void OnEnable()
        {
            base.OnEnable();
            
            velocity = Random.Range(velocity, velocity + 0.5f);
        }
    }

}
