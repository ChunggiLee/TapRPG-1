using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<GameObject> Slots = new List<GameObject>();
    public List<Item> Items = new List<Item>();
    public GameObject slots ;
    ItemDatabase database;
    int x = -315;
    int y = -330;
    public GameObject toolTip;
    public GameObject draggedItemGameObject;
    public bool draggingItem = false;
    public Item draggedItem;
    public int indexOfDraggedItem, characterSlotAmount = 0;
   public GameObject headSlot, clotheSlot, beltSlot, shoesSlot,
       handsSlot, mainWeaponSlot, subWeaponSlot, leftRingSlot, 
       rightRingSlot, necklaceSlot;
    int slotAmount = 0;

    public Vector3 Bar;

    // Use this for initialization
    void Start()
    { 

        database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        // toolTip = GameObject.FindGameObjectWithTag("ToolTip").GetComponent<GameObject>();
        //draggedItemGameObject = GameObject.FindGameObjectWithTag("droppedItemIcon").GetComponent<GameObject>();

        for (int i = 0; i < 4; i++)
        {
            for (int k = 0; k < 7; k++)
            {
                GameObject slot = (GameObject)Instantiate(slots);
                slot.GetComponent<SlotScript>().slotNumber = slotAmount;
                Slots.Add(slot);
                Items.Add(new Item(Item.ItemType.All));
                slot.transform.parent = this.gameObject.transform;
                slot.name = "slot" + i + "." + k;
                slot.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
                slot.GetComponent<RectTransform>().localPosition = new Vector3(x, y, 0);
                x = x + 105;
                if (k == 6)
                {
                    x = -315;
                    y = y - 102;
                }
                slotAmount++;
            }
        }

		for (int i = 0; i < database.size (); i++) {
			addItem (i);
		}
     
        CharacterSlotInit();

     
    }

    void Update()
    {
        if (draggingItem)
        {
            Vector3 posi = new Vector3(Input.mousePosition.x+20, Input.mousePosition.y-20, 10);
            draggedItemGameObject.GetComponent<RectTransform>().localPosition = Camera.main.ScreenToWorldPoint(posi) * 150;
            draggedItemGameObject.GetComponent<RectTransform>().localScale = new Vector2(2,2);
            //Debug.Log("x : " + posi.x + ", y : " + posi.y + ", z : " + posi.z);
        }

    }

    public void ShowToolTip(Vector3 toolPosition, Item item)
    {
        toolTip.SetActive(true);
        toolTip.GetComponent<RectTransform>().localPosition = new Vector3(toolPosition.x, toolPosition.y, toolPosition.z);

        toolTip.transform.GetChild(0).GetComponent<Text>().text = item.itemName;
        toolTip.transform.GetChild(2).GetComponent<Text>().text = item.itemDecs;
    }

    public void CloseToolTip()
    {
        toolTip.SetActive(false);
    }

    public void CheckIfItemExist(int itemID, Item item)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if(Items[i].itemID == itemID)
            {
                Items[i].itemValue = Items[i].itemValue + 1;
                break;
            }
            else if (i == Items.Count - 1)
            {
                addItemAtEmptySlot(item);
            }
        }
    }

    void addItem(int id)
    {
        for (int i = 0; i < database.items.Count; i++)
        {
            if (database.items[i].itemID == id)
            {
                Item item = database.items[i];

                if(database.items[i].itemType == Item.ItemType.Consumable)
                {
                    CheckIfItemExist(id, item);
                    break;
                } else
                {
                    addItemAtEmptySlot(item);
                }

                
            }
        }
    }

    void addItemAtEmptySlot(Item item)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].itemName == null)
            {
                Items[i] = item;
                break;
            }
        }
    }

    public void showDraggedItem(Item item, int slotNumber)
    {
        Item.ItemType itemType = item.itemType;
        Debug.Log("show" + item.itemType);
        indexOfDraggedItem = slotNumber;
        CloseToolTip();
        draggedItemGameObject.SetActive(true);
        draggedItem = item;
        draggingItem = true;
        draggedItemGameObject.GetComponent<Image>().sprite = item.itemIcon;
        Debug.Log("change show" + item.itemType);
        Items[indexOfDraggedItem].itemType = itemType;

    }

    public void CloseDraggedItem()
    {
        draggingItem = false;
        draggedItemGameObject.SetActive(false);
    }

    public void CharacterSlotInit()
    {
        characterSlotAmount = slotAmount;
        headSlot = GameObject.FindGameObjectWithTag("headSlot");
        Items.Add(new Item( Item.ItemType.Head));
        headSlot.GetComponent<SlotScript>().slotNumber = characterSlotAmount++;

        clotheSlot = GameObject.FindGameObjectWithTag("clotheSlot");
        Items.Add(new Item( Item.ItemType.Clothes));
        clotheSlot.GetComponent<SlotScript>().slotNumber = characterSlotAmount++;
        
        beltSlot = GameObject.FindGameObjectWithTag("beltSlot");
        Items.Add(new Item(Item.ItemType.Belt));
        beltSlot.GetComponent<SlotScript>().slotNumber = characterSlotAmount++;
        
        shoesSlot = GameObject.FindGameObjectWithTag("shoesSlot");
        Items.Add(new Item( Item.ItemType.Shoes));
        shoesSlot.GetComponent<SlotScript>().slotNumber = characterSlotAmount++;
        
        handsSlot = GameObject.FindGameObjectWithTag("handsSlot");
        Items.Add(new Item( Item.ItemType.Hands));
        handsSlot.GetComponent<SlotScript>().slotNumber = characterSlotAmount++;
        
        mainWeaponSlot = GameObject.FindGameObjectWithTag("mainWeaponSlot");
        Items.Add(new Item( Item.ItemType.Weapon));
        mainWeaponSlot.GetComponent<SlotScript>().slotNumber = characterSlotAmount++;
        
        subWeaponSlot = GameObject.FindGameObjectWithTag("subWeaponSlot");
        Items.Add(new Item( Item.ItemType.Weapon));
        subWeaponSlot.GetComponent<SlotScript>().slotNumber = characterSlotAmount++;
        
        leftRingSlot = GameObject.FindGameObjectWithTag("leftRingSlot");
        Items.Add(new Item( Item.ItemType.Rings));
        leftRingSlot.GetComponent<SlotScript>().slotNumber = characterSlotAmount++;
        
        rightRingSlot = GameObject.FindGameObjectWithTag("rightRingSlot");
        Items.Add(new Item( Item.ItemType.Rings));
        rightRingSlot.GetComponent<SlotScript>().slotNumber = characterSlotAmount++;
        
        necklaceSlot = GameObject.FindGameObjectWithTag("necklaceSlot");
        Items.Add(new Item( Item.ItemType.Necklace));
        necklaceSlot.GetComponent<SlotScript>().slotNumber = characterSlotAmount;

    }
}
