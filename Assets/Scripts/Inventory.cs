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
            Debug.LogWarning("More than onn instance of Inventory found!!");
        }
        Instance = this;

    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();

    public int space = 20;
    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }
            items.Add(item);
            onItemChangedCallback?.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        onItemChangedCallback?.Invoke();
    }
}
