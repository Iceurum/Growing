using UnityEngine;

public class InventoryManager : MonoBehaviour {
    
    public Inventory inventory;

    public void AddItem(string itemName, int amount) {
        inventory.AddItem(itemName, amount);
        Debug.Log("Item ditambahkan: " + itemName + " x" + amount);
    }

    public int GetAmount(string itemName) {
        return inventory.GetAmount(itemName);
    }

    public void PrintInventory() {
        foreach (var item in inventory.GetItems()) {
            Debug.Log(item.Key + " x" + item.Value);
        }
    }
}
