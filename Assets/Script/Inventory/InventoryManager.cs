using UnityEngine;

public class InventoryManager : MonoBehaviour {

    public Inventory inventory;
    public GameManager gameManager;

    public void AddItem(string itemName, int amount) {
        inventory.AddItem(itemName, amount);
        foreach (var item in inventory.GetItems()) {
            Debug.Log(item.Key + " x" + item.Value);
        }
        gameManager.CheckWinCondition();
    }

    public int GetAmount(string itemName) {
        return inventory.GetAmount(itemName);
    }
}