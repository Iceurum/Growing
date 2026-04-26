using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    
    private Dictionary<string, int> items = new Dictionary<string, int>();

    public void AddItem(string itemName, int amount) {
        if (items.ContainsKey(itemName)) {
            items[itemName] += amount;
        } else {
            items[itemName] = amount;
        }
        Debug.Log(itemName + " x" + items[itemName]);
    }

    public Dictionary<string, int> GetItems() {
        return items;
    }

    public int GetAmount(string itemName) {
        if (items.ContainsKey(itemName)) {
            return items[itemName];
        }
        return 0;
    }
}
