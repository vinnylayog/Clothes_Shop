using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Interactable
{
    public SpriteRenderer speechBubble;
    public Sprite[] speechSprites;
    public Sprite maxClicksSpeech;

    public AudioClip[] shopGrunts;

    int clicks = 0;

    //Opens Shop Panel when ShopNPC is interacted with
    public override void Interact()
    {
        base.Interact();

        if (!ShopManager.Instance.ShopPanel.activeSelf && !InventoryManager.Instance.myInventoryUI.inventoryUI.activeSelf)
        {
            ShopManager.Instance.OpenCloseShop();
            AudioManager.Instance.PlaySFX(shopGrunts[Random.Range(0, shopGrunts.Length)]);
        }
        else
        {
            clicks++;
            if (clicks > 50)
            {
                speechBubble.sprite = maxClicksSpeech;
            }
            else
            {
                speechBubble.sprite = speechSprites[Random.Range(0, speechSprites.Length)];
                AudioManager.Instance.PlaySFX(shopGrunts[Random.Range(0, shopGrunts.Length)]);
            }
        }
    }

    private void Update()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        if (Vector2.Distance(player.transform.position, transform.position) <= radius && !speechBubble.gameObject.activeSelf)
        {
            speechBubble.gameObject.SetActive(true);
            speechBubble.sprite = speechSprites[4];
        }
        else if (Vector2.Distance(player.transform.position, transform.position) > radius)
        {
            speechBubble.gameObject.SetActive(false);
            clicks = 0;
        }
    }
}
