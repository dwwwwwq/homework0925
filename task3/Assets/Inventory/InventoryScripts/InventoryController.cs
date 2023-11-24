using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inventoryCanvas;
    bool isOpen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        
        isOpen=!isOpen;
        inventoryCanvas.SetActive(isOpen);
        // 切换画布的显示与隐藏状态
        
        
    }
}