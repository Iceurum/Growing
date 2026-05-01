using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    [Header("References")]
    public InventoryManager inventoryManager;

    [Header("Win Condition")]
    public int turnipRequired = 10;
    public int potatoRequired = 5;

    [Header("Events")]
    public UnityEvent onWin;

    private bool hasWon = false;

    // Dipanggil oleh InventoryManager setiap kali item ditambah
    public void CheckWinCondition() {
        if (hasWon) return;

        int turnipCount  = inventoryManager.GetAmount("Turnip");
        int potatoCount  = inventoryManager.GetAmount("Potato");

        if (turnipCount >= turnipRequired && potatoCount >= potatoRequired) {
            hasWon = true;
            onWin.Invoke();
            Debug.Log("Menang! Turnip: " + turnipCount + " Potato: " + potatoCount);
        }
    }
}
