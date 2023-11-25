using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryManager : MonoBehaviour
{
    public static inventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    public slot slotPrefab;

    void Awake()
    {
        if(instance!=null)
            Destroy(this);
        instance=this;
    }

    private void OnEnable()
    {
        RefreshItem();
    }

    public static void CreateNewItem(Item item)
    {
        slot newItem=Instantiate(instance.slotPrefab,instance.slotGrid.transform);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem=item;
        newItem.slotNum.text= item.itemHeld.ToString();
        newItem.slotName.text=item.itemName;
    }

    public static void RefreshItem()
    {
        for(int i=0;i<instance.slotGrid.transform.childCount;i++)
        {
             if(instance.slotGrid.transform.childCount==0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        for(int i=0;i<instance.myBag.itemList.Count;i++)
        {
            CreateNewItem(instance.myBag.itemList[i]);
        }
    }
}
