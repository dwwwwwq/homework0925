using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : Singleton<InventoryController>
{
    public GameObject inventoryCanvas;
    public Transform playerTransform;
    bool isOpen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory();
        }

         for (int i = 1; i <= 9; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                DropItemFromSlot(i - 1); // Adjust to 0-based index
            }
        }
    }

    void ToggleInventory()
    {
        
        isOpen=!isOpen;
        inventoryCanvas.SetActive(isOpen);
        // 切换画布的显示与隐藏状态
        
        
    }

    void DropItemFromSlot(int slotIndex)
    {
        // Check if the slot index is valid
        if (slotIndex >= 0 && slotIndex < inventoryManager.instance.myBag.itemList.Count)
        {
            Item itemToDrop = inventoryManager.instance.myBag.itemList[slotIndex];

            // Check if the slot has an item
            if (itemToDrop != null)
            {
                // Drop the item in the scene near the player
                DropItemInScene(itemToDrop, slotIndex);
            }
        }
    }

    void DropItemInScene(Item item, int slotIndex)
    {
        Vector3 dropPosition = playerTransform.position + playerTransform.forward * 2f-new Vector3(0f, 1f, 0f); // Example: drop 2 units in front of the player

        // Instantiate a new item prefab in the scene near the player
        GameObject droppedItem = Instantiate(item.itemPrefab, dropPosition, Quaternion.identity);

        // Remove the item from the inventory or decrease its count
        if (item.itemHeld > 1)
        {
            // Decrease the count if there are multiple items
            item.itemHeld--;
            inventoryManager.RefreshItem();
        }
        else
        {
            // Remove the item from the inventory if there is only one
            inventoryManager.instance.myBag.itemList.RemoveAt(slotIndex);
            inventoryManager.RefreshItem();
        }
    }
}