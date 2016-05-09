using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class SlotScript : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler
{

    public Item item;
    public Item.ItemType change;
    Image itemImage;
    public int slotNumber;
    Inventory inventory;

    Text itemAmount;

    void Start()
    {
        itemAmount = gameObject.transform.GetChild(1).GetComponent<Text>();
        itemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    void Update()
    {
        if (inventory.Items[slotNumber].itemName != null)
        {
            itemAmount.enabled = false;
            item = inventory.Items[slotNumber];
            itemImage.enabled = true;
            itemImage.sprite = inventory.Items[slotNumber].itemIcon;

            if(inventory.Items[slotNumber].itemType == Item.ItemType.Consumable)
            {
                itemAmount.enabled = true;
                itemAmount.text = "" + inventory.Items[slotNumber].itemValue;
            }
        }
        else
        {
            itemImage.enabled = false;
        }


    }

    public void Click()
    {
       // Debug.Log("Clicked");
    }

    public void OnPointerDown(PointerEventData data)
    {
        
        if (inventory.Items[slotNumber].itemType == Item.ItemType.Consumable)
        {
            inventory.Items[slotNumber].itemValue--;
            if(inventory.Items[slotNumber].itemValue == 0)
            {
                inventory.Items[slotNumber] = new Item();
                itemAmount.enabled = false;
                inventory.CloseToolTip();
            }
        }

       

        if (inventory.Items[slotNumber].itemName == null && inventory.draggingItem)
        {
           // Debug.Log("if before : " + inventory.Items[slotNumber].itemType);
            Item.ItemType itemType = inventory.Items[slotNumber].itemType;
                inventory.Items[slotNumber] = inventory.draggedItem;
                inventory.CloseDraggedItem();
            inventory.Items[slotNumber].itemType = itemType;
           // Debug.Log("if after : " + inventory.Items[slotNumber].itemType);


        }
        else if (inventory.draggingItem && inventory.Items[slotNumber].itemName != null) 
        {
           // Debug.Log("else before : " + inventory.Items[slotNumber].itemType);
            Item.ItemType itemType = inventory.Items[slotNumber].itemType;
            inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
                inventory.Items[slotNumber] = inventory.draggedItem;
                inventory.CloseDraggedItem();
            inventory.Items[slotNumber].itemType = itemType;
           // Debug.Log("else after : " + inventory.Items[slotNumber].itemType);

        }
        
    }

    public void OnPointerEnter(PointerEventData data)
    {
       // Debug.Log("click : " + inventory.Items[slotNumber].itemType);
        if (inventory.Items[slotNumber].itemName != null && !inventory.draggingItem)
        {
            inventory.ShowToolTip(inventory.Slots[slotNumber].GetComponent<RectTransform>().localPosition, inventory.Items[slotNumber]);
        } 
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (inventory.Items[slotNumber].itemName != null)
        {
            inventory.CloseToolTip();
        }
    }

    public void OnDrag(PointerEventData data)
    {
       // Debug.Log("Drag : " + inventory.Items[slotNumber].itemType);
        if (inventory.Items[slotNumber].itemType == Item.ItemType.Consumable)
        {
            inventory.Items[slotNumber].itemValue++;
        }

        if (inventory.Items[slotNumber].itemName != null)
        {
            Item.ItemType itemType = inventory.Items[slotNumber].itemType;
            inventory.showDraggedItem(inventory.Items[slotNumber], slotNumber);
            itemAmount.enabled = false;
            change = new Item.ItemType();
            change = inventory.Items[slotNumber].itemType;
            inventory.Items[slotNumber] = new Item();
            inventory.Items[slotNumber].itemType = itemType;
        }
    }

}
