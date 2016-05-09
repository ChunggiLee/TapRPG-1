using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

    public List<Item> items = new List<Item>();

    void Start()
    {
		items.Add(new Item("Item/accessory_02", 0, "Nice accessory", 0, 0, 0, Item.ItemType.Necklace));
		items.Add(new Item("Item/accessory_05", 1, "Better accessory", 0, 0, 0, Item.ItemType.Necklace));
		items.Add(new Item("Item/accessory_11", 2, "Nice accessory", 0, 0, 0, Item.ItemType.Rings));
		items.Add(new Item("Item/armor_003", 3, "Nice armor", 0, 0, 0, Item.ItemType.Clothes));
		items.Add(new Item("Item/armor_016", 4, "Better Armor", 0, 0, 0, Item.ItemType.Clothes));
		items.Add(new Item("Item/boot_02", 5, "Nice boot", 0, 0, 0, Item.ItemType.Shoes));
		items.Add(new Item("Item/boot_14", 6, "Nice boot", 0, 0, 0, Item.ItemType.Shoes));
		items.Add(new Item("Item/drops_07", 7, "Better drops", 0, 0, 0, Item.ItemType.Drops));
		items.Add(new Item("Item/food_03", 8, "Nice food", 0, 0, 0, Item.ItemType.Consumable));
		items.Add(new Item("Weapon/Arrow/Arrow1", 6, "Nice boot", 0, 0, 0, Item.ItemType.Weapon));
		items.Add(new Item("Weapon/Star/Star1", 7, "Better drops", 0, 0, 0, Item.ItemType.Weapon));
		items.Add(new Item("Weapon/Swoard/Swoard1", 8, "Nice food", 0, 0, 0, Item.ItemType.Weapon));


    }

	public int size(){
		return items.Count;
	}
}
