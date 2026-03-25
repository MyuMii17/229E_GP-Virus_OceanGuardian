using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainInventory : MonoBehaviour
{
    public int maxSlot = 9;
    public List<ItemData> items = new();
    [SerializeField] private GameObject InvPanel;
    public MonoBehaviour ThirdPersonCamera;
    private bool isCanUse = false;
    public void Awake()
    {
        items = new List<ItemData>(maxSlot);
        for(int i = 0; i < maxSlot; i++)
        {
            items.Add(null);
        }
    }
    public void Start()
    {
        
    }
    public void Update()
    {
        bool isCheckClick = Keyboard.current.tabKey.wasPressedThisFrame;
        if (isCheckClick)
        {
            CursorON();
        }
    }
    public bool AddCheck(ItemData item)
    {
        Debug.Log("Current Count: " + items.Count);
        int itemIndex = items.IndexOf(null);
        Debug.Log("Empty Index: " + itemIndex);
        // if(items.Contains(item))
        //     return false;

        if(itemIndex == -1)
           return false;

        items[itemIndex] = item;
        return true;
 
    }

    public bool HasItem(ItemData item)
    {
        return items.Contains(item);
    }

    public void ItemCheck(int index)
    {
        if(index < 0 || index >= items.Count)
        {
            return;
        }
        Debug.Log(index);
        DropItem(items[index]);

        items[index] = null;
    }
    public void DropItem(ItemData item)
    {
        Debug.Log("Spawn");
        Vector3 dropPosition = transform.position + transform.forward;

        Instantiate(item.worldPreFeb, dropPosition, Quaternion.identity);
    }

    private void CursorON()
    {
        isCanUse = !isCanUse;

        if (isCanUse && !InvPanel.activeSelf)
        {
            ThirdPersonCamera.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if(!InvPanel.activeSelf)
        {
            ThirdPersonCamera.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

}
