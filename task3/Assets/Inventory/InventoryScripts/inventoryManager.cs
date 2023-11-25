using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryManager : MonoBehaviour
{
    static inventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    public slot slotPrefab;

    void Awake()
    {
        if(instance!=null)
            Destroy(this);
        instance=this;
    }

    public static void CreateNewItem(Item item)
    {
        slot newItem=Instantiate(instance.slotPrefab,instance.slotGrid.transform);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem=item;
        newItem.slotNum.text= item.itemHeld.ToString();
        newItem.slotName.text=item.itemName;
    }
}
