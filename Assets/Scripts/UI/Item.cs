using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public string itemName;
    public int itemID;
    public string itemDecs;
    public Sprite itemIcon;
    public GameObject itemModel;
    public int itemPower;
    public int itemSpeed;
    public int itemValue;
    public ItemType itemType;
    public Item item;

    public enum ItemType
    {
        All,
        Weapon,
        Consumable,
        Quest,
        Head,
        Shoes,
        Clothes,
        Belt,
        Earrings,
        Necklace,
        Rings,
        Hands,
		Drops
    }

    public Item(string name, int id, string desc, int power, int speed, int value, ItemType type)
    {
        itemName = name;
        itemID = id;
        itemDecs = desc;
        itemPower = power;
        itemSpeed = speed;
        itemValue = value;
        itemType = type;
        itemIcon = Resources.Load<Sprite>("" + name);
    }

    public Item()
    {
        
    }

    public Item(Item.ItemType type)
    {
        itemType = type;
    }

    public Item(Item copyItem)
    {
        item = copyItem;
    }

    public Item Clone()
    {
        return new Item(item);
    }
}
