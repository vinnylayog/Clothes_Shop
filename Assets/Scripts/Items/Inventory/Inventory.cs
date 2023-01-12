using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        Instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int inventorySpace = 20;

    public List<Item> items = new List<Item>();

    public GameObject DefaultItem;

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= inventorySpace)
            {
                Debug.Log("Not enough room.");
                return false;
            }
            items.Add(item);

            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(Item item, bool drop)
    {
        if (drop)
        {
            Transform playerTransform = GameManager.Instance.Player.transform;
            GameObject removeItem = Instantiate(DefaultItem, playerTransform.position, Quaternion.identity);
            removeItem.GetComponent<ItemPickup>().OnSpawn(item);
            removeItem.transform.SetParent(GameManager.Instance.ActorsParent.transform);
        }

        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
