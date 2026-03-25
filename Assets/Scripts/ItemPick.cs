using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemPick : MonoBehaviour
{
    public ItemData item;

    public void OnPickItem(MainInventory inventory)
    {
        if (item.isItem)
        {
            bool isSucces = inventory.AddCheck(item);
            if (isSucces)
            {
                Destroy(gameObject);
            }
        }
    }

    internal void OnPickItem(object inventory)
    {
        throw new NotImplementedException();
    }
}
